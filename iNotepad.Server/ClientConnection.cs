using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    class ClientConnection : IDisposable
    {
        private NetworkStream Stream { get; set; }
        private readonly IAutocompleteService _autocompele;

        public ClientConnection(TcpClient tcpClient, IAutocompleteService autocompele)
        {
            Stream = tcpClient.GetStream();
            _autocompele = autocompele;
        }

        public async Task Handle()
        {
            var buffer = new byte[Config.RequestLength];
            for (; ; )
            {
                try
                {
                    // Читаем данные
                    var bytesRead = await Stream.ReadAsync(buffer, 0, buffer.Length);
                    // Если даных нет, то закроем соединение
                    if (bytesRead == 0)
                        return;

                    var request = Encoding.ASCII.GetString(buffer);

                    ProcessRequest(request);
                }
                catch (System.IO.IOException)
                {
                    return;
                }
            }
        }

        private void ProcessRequest(string request)
        {
            // Проверяем запрос на соответствие паттерну "get <prefix>". 
            var match = Regex.Match(request, "get (\\w{1,15})");
            if (!match.Success) return;

            var prefix = match.Groups[1].Value;

            // Получим возможные варианты слов
            var words = _autocompele.GetWordsByPrefix(prefix);

            var response = PrepareResponse(words);

            // Пошлем ответ
            SendResponse(response);
        }

        private static string PrepareResponse(IEnumerable<string> words)
        {
            var response = words.Aggregate("", (current, word) => current + (word + "\n"));
            if (response.Length == 0)
            {
                response = "\n";
            }

            return response;
        }

        private async void SendResponse(string response)
        {
            var data = Encoding.ASCII.GetBytes(response);

            await Stream.WriteAsync(data, 0, data.Length);
            await Stream.FlushAsync();
        }

        public void Dispose()
        {
            if (Stream == null) return;

            Stream.Dispose();
            Stream = null;
        }
    }
}