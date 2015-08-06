using AutocompleteClassLibrary;

namespace iNotepad
{
    class ConsoleAutocompleteProcessor
    {
        private IWordsRetriever WordsRetriever { get; set; }
        private IRequestsRetriever RequestsRetriever { get; set; }
        private IAutocompleteService AutocompleteService { get; set; }

        public ConsoleAutocompleteProcessor(IWordsRetriever wordsRetriever, IRequestsRetriever requestsRetriever, IAutocompleteService autocompleteService)
        {
            WordsRetriever = wordsRetriever;
            AutocompleteService = autocompleteService;
            RequestsRetriever = requestsRetriever;
        }

        public void Start()
        {
            var words = WordsRetriever.Retrieve();

            AutocompleteService.LoadWords(words);

            RequestsRetriever.Retrieve(AutocompleteService);
        }
    }
}
