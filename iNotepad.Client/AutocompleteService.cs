using System;
using System.Net.Sockets;
using System.Text;
using AutocompleteClassLibrary;

namespace iNotepad.Client
{
    public class AutocompleteService
    {
        private readonly string _hostname;
        private readonly int _port;
        private TcpClient TcpClient { get; set; }
        private NetworkStream Stream { get; set; }

        public AutocompleteService(string hostname, int port)
        {
            _hostname = hostname;
            _port = port;

            TcpClient = new TcpClient();
        }

        ~AutocompleteService()
        {
            TcpClient.Close();
            Stream.Close();
        }

        public async void Connect()
        {
            await TcpClient.ConnectAsync(_hostname, _port);
            Stream = TcpClient.GetStream();
        }

        public async void Retrieve(string prefix)
        {
            var request = PrepareRequest(prefix);

            var requestEncoded = Encoding.ASCII.GetBytes(request);

            try
            {
                await Stream.WriteAsync(requestEncoded, 0, requestEncoded.Length);

                var buffer = new byte[TcpClient.ReceiveBufferSize];

                var responseLength = await Stream.ReadAsync(buffer, 0, buffer.Length);
                var response = Encoding.ASCII.GetString(buffer, 0, responseLength);

                Console.WriteLine(response);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Сервис временно недоступен. Повторите попытку позднее.");
            }
        }

        private static string PrepareRequest(string prefix)
        {
            var request = string.Format("get {0}", prefix);

            // Если длина запроса меньше, чем того требует протокол, то дополним его до нужной длины нулевыми символами
            if (request.Length < Config.RequestLength)
            {
                request = request.PadRight(Config.RequestLength, '\0');
            }

            return request;
        }
    }
}
