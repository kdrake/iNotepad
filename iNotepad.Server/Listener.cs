using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    public class Listener : IListener
    {
        private IAutocompleteService Autocompele { get; set; }

        private readonly TcpListener _tcpListener;
        private readonly int _port;

        public Listener(int port)
        {
            _port = port;
            _tcpListener = new TcpListener(IPAddress.Any, _port);
        }

        public void Listen(IAutocompleteService autocompele)
        {
            Autocompele = autocompele;

            _tcpListener.Start();

            Task.Factory.StartNew(ListenLoop);

            Console.WriteLine("Listening on port {0}.", _port);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        private async void ListenLoop()
        {
            for (; ; )
            {
                using (var tcpClient = await _tcpListener.AcceptTcpClientAsync())
                {
                    using (var clientConnection = new ClientConnection(tcpClient, Autocompele))
                    {
                        await clientConnection.Handle();
                    }
                }
            }
        }
    }
}