using System.Collections.Generic;
using System.Linq;

namespace AnagramCheck
{
    public class AnagramChecker
    {
        public bool Check(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            var symbolsCount = new Dictionary<char, short>();

            for(var i = 0; i < word1.Length; i++)
            {
                char symbol1 = word1[i];
                if (!symbolsCount.ContainsKey(symbol1))
                {
                    symbolsCount[symbol1] = 1;
                }
                else
                {
                    symbolsCount[symbol1] += 1;
                }

                char symbol2 = word2[i];
                if (!symbolsCount.ContainsKey(symbol2))
                {
                    symbolsCount[symbol2] = -1;
                }
                else
                {
                    symbolsCount[symbol2] -= 1;
                }
            }

            return symbolsCount.Values.All(n => n == 0);
        }
    }
}
