using System.Collections.Generic;

namespace AutocompleteClassLibrary
{
    public interface IAutocompeleProcessor
    {
        void LoadWords(Word[] words);
        IEnumerable<string> GetByPrefix(string prefix);
    }
}