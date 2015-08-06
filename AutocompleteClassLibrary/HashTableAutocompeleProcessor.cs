using System;
using System.Collections.Generic;

namespace AutocompleteClassLibrary
{
    public class HashTableAutocompeleProcessor : IAutocompeleProcessor
    {
        private Dictionary<string, List<string>> HashTable { get; set; }

        public void LoadWords(Word[] words)
        {
            Array.Sort(words);

            HashTable = new Dictionary<string, List<string>>(words.Length);

            foreach (var word in words)
            {
                for (var i = 1; i <= word.Text.Length; i++)
                {
                    var prefix = word.Text.Substring(0, i);

                    if (HashTable.ContainsKey(prefix))
                    {
                        if (HashTable[prefix].Count < 10)
                        {
                            HashTable[prefix].Add(word.Text);
                        }
                    }
                    else
                    {
                        HashTable[prefix] = new List<string> { word.Text };
                    }
                }
            }
        }

        public IEnumerable<string> GetByPrefix(string prefix)
        {
            List<string> possibleWords;
            if (!HashTable.TryGetValue(prefix, out possibleWords))
            {
                possibleWords = new List<string>();
            }

            return possibleWords;
        }
    }
}
