using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int portNumber;
            int.TryParse(args[1], out portNumber);

            var pathToDict = args[0];

            new AutocompleteServerProcessor(new FileWordsRetriever(pathToDict), new Listener(portNumber), new AutocompeleService()).Start();
        }
    }
}
