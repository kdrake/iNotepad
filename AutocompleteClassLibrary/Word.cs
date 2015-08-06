using System;

namespace AutocompleteClassLibrary
{
    public class Word : IComparable<Word>
    {
        public string Text { get; set; }
        public int Rate { get; set; }

        public int CompareTo(Word other)
        {
            if (Rate > other.Rate)
            {
                return -1;
            }
            else if (Rate < other.Rate)
            {
                return 1;
            }
            else
            {
                return string.Compare(Text, other.Text, StringComparison.Ordinal);
            }
        }
    }
}