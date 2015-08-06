using System;
using AutocompleteClassLibrary;

namespace iNotepad
{
    class ConsoleWordsRetriever : IWordsRetriever
    {
        public Word[] Retrieve()
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);

            var words = new Word[n];

            for (var i = 0; i < n; ++i)
            {
                var line = Console.ReadLine();
                var split = line.Split(' ');

                int rate;
                int.TryParse(split[1], out rate);

                words[i] = new Word { Text = split[0], Rate = rate };
            }

            return words;
        }
    }
}
