using System;
using System.Linq;
using AutocompleteClassLibrary;
using NUnit.Framework;

namespace iNotepad.Test
{
    [TestFixture]
    public class WordTest
    {
        [Test]
        public void TestGetSortedWordList()
        {
            var source = new[]
            {
                new Word {Text = "kare", Rate = 10},
                new Word {Text = "kabojo", Rate = 20},
                new Word {Text = "kanojo", Rate = 20},
                new Word {Text = "karetachi", Rate = 1},
                new Word {Text = "korosu", Rate = 7},
                new Word {Text = "karosu", Rate = 7},
                new Word {Text = "sakura", Rate = 3},
                new Word {Text = "accccaabbc", Rate = 3016},
                new Word {Text = "accccaabba", Rate = 634},
                new Word {Text = "acacbccb", Rate = 634},
                new Word {Text = "aacbabbabbb", Rate = 122},
                new Word {Text = "abbacbac", Rate = 744},
                new Word {Text = "cbbbbaabaca", Rate = 712},
                new Word {Text = "abcaccacbc", Rate = 3016}
            };

            Array.Sort(source);
            var actual = source.Select(w => w.Text).ToArray();

            var expected = new[]
            {
                "abcaccacbc",
                "accccaabbc",
                "abbacbac",
                "cbbbbaabaca",
                "acacbccb",
                "accccaabba",
                "aacbabbabbb",
                "kabojo", 
                "kanojo",
                "kare", 
                "karosu", 
                "korosu",
                "sakura", 
                "karetachi"
            };

            Assert.AreEqual(expected, actual);
        }
    }
}
