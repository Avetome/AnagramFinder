using System.Collections.Generic;

namespace AnagramCheck
{
    public class AnagramFinder
    {
        public List<List<string>> FindAnagrams(List<string> words)
        {
            var result = new List<List<string>>();

            var anagramsNumber = new HashSet<ushort>();

            var anagramChecker = new AnagramChecker();

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
                    result.Add(currentWordAnagrams);
                }
            }

            return result;
        }
    }
}
