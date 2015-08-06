using System.Collections.Generic;
using AutocompleteClassLibrary;
using NUnit.Framework;

namespace iNotepad.Test
{
    [TestFixture]
    public class AutocompeleTest
    {
        [Test]
        public void GetWordsByPrefixTest()
        {
            var words = new[]
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

            var autocompele = new AutocompeleService();
            autocompele.LoadWords(words);

            Assert.AreEqual(new List<string> { "kabojo", "kanojo", "kare", "karosu", "karetachi" }, autocompele.GetWordsByPrefix("ka"));
            Assert.AreEqual(new List<string> { "korosu" }, autocompele.GetWordsByPrefix("ko"));
            Assert.AreEqual(new List<string> { "kare", "karosu", "karetachi" }, autocompele.GetWordsByPrefix("kar"));
            Assert.AreEqual(new List<string>(), autocompele.GetWordsByPrefix(""));
            Assert.AreEqual(new List<string>(), autocompele.GetWordsByPrefix("www"));
            Assert.AreEqual(new List<string> { "abcaccacbc", "accccaabbc", "abbacbac", "acacbccb", "accccaabba", "aacbabbabbb" }, autocompele.GetWordsByPrefix("a"));
            Assert.AreEqual(new List<string> { "abcaccacbc", "abbacbac" }, autocompele.GetWordsByPrefix("ab"));
            Assert.AreEqual(new List<string> { "aacbabbabbb" }, autocompele.GetWordsByPrefix("aa"));

            words = new[]
            {
                new Word {Text = "aa", Rate = 10},
                new Word {Text = "ab", Rate = 10},
                new Word {Text = "ac", Rate = 10},
                new Word {Text = "ad", Rate = 10},
                new Word {Text = "ae", Rate = 10},
                new Word {Text = "af", Rate = 10},
                new Word {Text = "ag", Rate = 10},
                new Word {Text = "ah", Rate = 10},
                new Word {Text = "ai", Rate = 10},
                new Word {Text = "aj", Rate = 10},
                new Word {Text = "ak", Rate = 1}
            };

            autocompele.LoadWords(words);

            Assert.AreEqual(new List<string>(), autocompele.GetWordsByPrefix(""));
            Assert.AreEqual(new List<string>(), autocompele.GetWordsByPrefix("c"));
            Assert.AreEqual(new List<string> { "ab" }, autocompele.GetWordsByPrefix("ab"));
            Assert.AreEqual(new List<string> { "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj" }, autocompele.GetWordsByPrefix("a"));
        }
    }
}
