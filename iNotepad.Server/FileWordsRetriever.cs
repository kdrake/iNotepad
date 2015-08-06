using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutocompleteClassLibrary;

namespace iNotepad.Server
{
    class FileWordsRetriever : IWordsRetriever
    {
        private readonly string _pathToDict;

        public FileWordsRetriever(string pathToDict)
        {
            _pathToDict = pathToDict;
        }

        public Word[] Retrieve()
        {
            var words = new List<Word>();

            var path = Path.Combine("@", _pathToDict);

            var readText = File.ReadAllLines(path);

            foreach (var split in readText.Select(line => line.Split(' ')))
            {
                int rate;
                int.TryParse(split[1], out rate);

                words.Add(new Word { Text = split[0], Rate = rate });
            }

            return words.ToArray();
        }
    }
}
