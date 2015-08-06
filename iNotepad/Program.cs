using AutocompleteClassLibrary;

namespace iNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsoleAutocompleteProcessor(new ConsoleWordsRetriever(), new ConsoleRequestsRetriever(), new AutocompeleService()).Start();
        }
    }
}
