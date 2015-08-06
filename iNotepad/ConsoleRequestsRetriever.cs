using System;
using AutocompleteClassLibrary;

namespace iNotepad
{
    class ConsoleRequestsRetriever : IRequestsRetriever
    {
        public void Retrieve(IAutocompleteService autocompleteService)
        {
            int m;
            int.TryParse(Console.ReadLine(), out m);

            for (var i = 0; i < m; ++i)
            {
                var prefix = Console.ReadLine();
                foreach (var word in autocompleteService.GetWordsByPrefix(prefix))
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine();
            }
        }
    }
}
