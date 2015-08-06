using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    public class AutocompleteServerProcessor
    {
        private IListener Listener { get; set; }
        private IAutocompleteService AutocompleteService { get; set; }
        private IWordsRetriever WordsRetriever { get; set; }

        public AutocompleteServerProcessor(IWordsRetriever wordsRetriever, IListener listener, IAutocompleteService autocompleteService)
        {
            WordsRetriever = wordsRetriever;
            Listener = listener;
            AutocompleteService = autocompleteService;
        }

        public void Start()
        {
            var words = WordsRetriever.Retrieve();

            AutocompleteService.LoadWords(words);

            Listener.Listen(AutocompleteService);
        }
    }
}
