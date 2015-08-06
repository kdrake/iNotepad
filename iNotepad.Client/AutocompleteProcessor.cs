using System;
using System.Collections.Generic;

namespace iNotepad.Client
{
    class AutocompleteProcessor
    {
        private string Hostname { get; set; }
        private int Port { get; set; }

        public AutocompleteProcessor(IReadOnlyList<string> args)
        {
            int port;
            int.TryParse(args[1], out port);

            Port = port;
            Hostname = args[0];
        }

        public void Start()
        {
            var autocompleteService = new AutocompleteService(Hostname, Port);
            autocompleteService.Connect();

            string prefix;
            while ((prefix = Console.ReadLine()) != null)
            {
                autocompleteService.Retrieve(prefix);
            }
        }
    }
}
