using System.Collections.Generic;

namespace AutocompleteClassLibrary
{
    public class AutocompeleService : IAutocompleteService
    {
        public IAutocompeleProcessor Processor { get; set; }

        public AutocompeleService()
        {
            Processor = new HashTableAutocompeleProcessor();
        }
        
        public void LoadWords(Word[] words)
        {
            Processor.LoadWords(words);
        }

        public IEnumerable<string> GetWordsByPrefix(string prefix)
        {
            return Processor.GetByPrefix(prefix);
        }
    }
}
