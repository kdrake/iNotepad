using System.Collections.Generic;

namespace AutocompleteClassLibrary
{
    public interface IAutocompleteService
    {
        IAutocompeleProcessor Processor { get; set; }
        void LoadWords(Word[] words);
        IEnumerable<string> GetWordsByPrefix(string prefix);
    }
}