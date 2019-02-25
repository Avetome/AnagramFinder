using AnagramCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AnagramCheckTest
{
    public class AnagramFinderTests
    {
        [Theory(DisplayName = "Return empty list if there are no anagrams")]
        [MemberData(nameof(WithoutAnagrams))]
        public void ShouldReturnEmptyListIfThereAreNoAnagrams(List<string> words)
        {
            var anagramFinder = new AnagramFinder();

            var result = anagramFinder.FindAnagrams(words);

            Assert.Empty(result.Anagrams);
        }

        [Theory(DisplayName = "Return non empty list if there are anagrams")]
        [MemberData(nameof(WithAnagrams))]
        public void ShouldFindAnagrams(List<string> words)
        {
            var anagramFinder = new AnagramFinder();

            var result = anagramFinder.FindAnagrams(words);

            Assert.NotEmpty(result.Anagrams);
        }

        [Theory(DisplayName = "Return correct numbers of anagrams lists")]
        [MemberData(nameof(WithAnagramsAndCount))]
        public void ShouldFindAnagramsAndItsNumbers(AnagramFinderTestData data)
        {
            var anagramFinder = new AnagramFinder();

            var result = anagramFinder.FindAnagrams(data.Words);

            Assert.Equal(data.AnagramCount, result.Anagrams.Count);
            Assert.Equal(data.LongestWordWithAnagramLength, result.GetLongestWordWithAnagram().Length);
        }

        public static TheoryData<List<string>> WithoutAnagrams()
        {
            return new TheoryData<List<string>>
                {
                    new List<string>() { "good", "bad", "ugly" },
                    new List<string>() { "one", "two", "three" },
                    new List<string>() { "four", "five", "six" }
                };
        }

        public static TheoryData<List<string>> WithAnagrams()
        {
            return new TheoryData<List<string>>
                {
                    new List<string>() { "good", "doog", "ugly" },
                    new List<string>() { "one", "neo", "three" },
                    new List<string>() { "cat", "tac", "six" }
                };
        }

        public static TheoryData<AnagramFinderTestData> WithAnagramsAndCount()
        {
            return new TheoryData<AnagramFinderTestData>
                {
                    new AnagramFinderTestData(
                        new List<string>() { "one", "neo", "three" },
                        1, 3, 2),
                    new AnagramFinderTestData(
                        new List<string>() { "cat", "tac", "ugly", "listen", "silent" },
                        2, 6, 2),
                    new AnagramFinderTestData(
                        new List<string>() { "integral", "triangle", "knits", "stink", "rots", "sort" },
                        3, 8, 2),
                    new AnagramFinderTestData(
                        new List<string>() { "enlist", "skins", "inlets", "fresher", "boaters", "listen", "boaster", "silent", "borates", "tac", "refresh", "sinks", "knits", "stink", "sort", "cat", "rots" },
                        7, 7, 4),
                };
        }

        public class AnagramFinderTestData
        {
            public AnagramFinderTestData(
                List<string> words,
                byte anagramCount,
                ushort longestWordWithAnagramLength,
                ushort longestAnagramListLength)
            {
                Words = words;
                AnagramCount = anagramCount;
                LongestWordWithAnagramLength = longestWordWithAnagramLength;
                LongestAnagramListLength = longestAnagramListLength;
            }

            public List<string> Words { get; set; }

            public byte AnagramCount { get; set; }

            public ushort LongestWordWithAnagramLength { get; set; }

            public ushort LongestAnagramListLength { get; set; }
        }
    }
}
