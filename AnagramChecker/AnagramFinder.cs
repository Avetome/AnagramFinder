using System.Collections.Generic;
using System.Linq;

namespace AnagramCheck
{
    public class AnagramFinder
    {
        public AnagramFinderResult FindAnagrams(List<string> words)
        {
            var result = new AnagramFinderResult();

            var anagramsNumber = new HashSet<ushort>();
            var anagramChecker = new AnagramChecker();

            var longestWordWithAnagramLength = 0;
            var longestAnagramListLength = 0;

            for (var i = 0; i < words.Count - 1; i++)
            {
                if (anagramsNumber.Contains((ushort)i))
                {
                    continue;
                }

                var currentWord = words[i];

                List<string> currentWordAnagrams = null;

                for (var j = i + 1; j < words.Count; j++)
                {
                    var isAnagram = anagramChecker.Check(currentWord, words[j]);

                    if (isAnagram)
                    {
                        anagramsNumber.Add((ushort)j);

                        if (currentWordAnagrams == null)
                        {
                            currentWordAnagrams = new List<string>() { currentWord, words[j] };
                        }
                        else
                        {
                            currentWordAnagrams.Add(words[j]);
                        }
                    }
                }

                if (currentWordAnagrams != null)
                {
                    if (longestAnagramListLength < currentWordAnagrams.Count)
                    {
                        longestAnagramListLength = currentWordAnagrams.Count;

                        result.LongestListIndex = (ushort)result.Anagrams.Count;
                    }

                    if (longestWordWithAnagramLength < currentWord.Length)
                    {
                        longestWordWithAnagramLength = currentWord.Length;

                        result.LongestWordIndex = (ushort)result.Anagrams.Count;
                    }

                    result.Anagrams.Add(currentWordAnagrams);
                }
            }

            return result;
        }
    }

    public class AnagramFinderResult
    {
        public AnagramFinderResult()
        {
            Anagrams = new List<List<string>>();
        }

        public List<List<string>> Anagrams { get; set; }

        /// <summary>
        /// Index in <see cref="AnagramFinderResult.Anagrams"/>
        /// </summary>
        public ushort LongestWordIndex { private get; set; }

        /// <summary>
        /// Index in <see cref="AnagramFinderResult.Anagrams"/>
        /// </summary>
        public ushort LongestListIndex { private get; set; }

        public string GetLongestWordWithAnagram()
        {
            if (!Anagrams.Any() || LongestWordIndex >= Anagrams.Count)
            {
                return string.Empty;
            }

            return Anagrams[LongestWordIndex].First();
        }

        public List<string> GetLongestAnagramList()
        {
            if (!Anagrams.Any() || LongestListIndex >= Anagrams.Count)
            {
                return new List<string>();
            }

            return Anagrams[LongestListIndex];
        }
    }
}
