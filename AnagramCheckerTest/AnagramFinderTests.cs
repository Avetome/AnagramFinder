using AnagramCheck;
using System;
using System.Collections.Generic;
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

            Assert.Empty(result);
        }

        [Theory(DisplayName = "Return non empty list if there are anagrams")]
        [MemberData(nameof(WithAnagrams))]
        public void ShouldFindAnagrams(List<string> words)
        {
            var anagramFinder = new AnagramFinder();

            var result = anagramFinder.FindAnagrams(words);

            Assert.NotEmpty(result);
        }

        [Theory(DisplayName = "Return correct numbers of anagrams lists")]
        [MemberData(nameof(WithAnagramsAndCount))]
        public void ShouldFindAnagramsAndItsNumbers((List<string> words, byte anagramCount) data)
        {
            var anagramFinder = new AnagramFinder();

            var result = anagramFinder.FindAnagrams(data.words);

            Assert.Equal(data.anagramCount, result.Count);
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

        public static TheoryData<(List<string> words, byte anagramCount)> WithAnagramsAndCount()
        {
            return new TheoryData<(List<string> words, byte anagramCount)>
                {
                    (new List<string>() { "one", "neo", "three" }, 1),
                    (new List<string>() { "cat", "tac", "ugly", "listen", "silent" }, 2),
                    (new List<string>() { "integral", "triangle", "knits", "stink", "rots", "sort" }, 3),
                    (new List<string>() { "enlist", "skins", "inlets", "fresher", "boaters", "listen", "boaster", "silent", "borates", "tac", "refresh", "sinks", "knits", "stink", "sort", "cat", "rots" }, 7),
                };
        }
    }
}
