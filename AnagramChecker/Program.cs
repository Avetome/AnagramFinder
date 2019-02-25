using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramCheck
{
    class Program
    {
        private const ConsoleColor NormalColor = ConsoleColor.White;
        private const ConsoleColor QuiteColor = ConsoleColor.Gray;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Anagram finder";

            var filename = args.Any() ? args[0] : "words.txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found");
            }

            var words = ReadFromFile(filename);

            Console.WriteLine($"Words in file: {Environment.NewLine}");

            WriteList(words);

            var result = new AnagramFinder().FindAnagrams(words);

            WriteResults(result);

            Console.ReadKey();
        }

        private static void WriteResults(AnagramFinderResult result)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Results: {Environment.NewLine}");

            foreach (var list in result.Anagrams)
            {
                WriteList(list);
            }

            Console.WriteLine();            

            Console.Write("The longest word with anagram (first in their list) is ");
            Console.ForegroundColor = QuiteColor;
            Console.Write($"{result.GetLongestWordWithAnagram()}");
            Console.ForegroundColor = NormalColor;

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The longest anagram list is: ");
            Console.ForegroundColor = QuiteColor;
            WriteList(result.GetLongestAnagramList());
            Console.ForegroundColor = NormalColor;
        }

        private static void WriteList(List<string> list)
        {
            Console.ForegroundColor = QuiteColor;

            foreach (var word in list)
            {
                Console.Write($"{word} ");
            }

            Console.ForegroundColor = NormalColor;

            Console.WriteLine();
        }

        private static List<string> ReadFromFile(string filename)
        {
            // We don't think about extremely large files yet.

            string line;
            List<string> result = new List<string>();

            using (var inputFile = new StreamReader(filename))
            {
                Console.ForegroundColor = QuiteColor;
                Console.WriteLine($"Processing file {filename} {Environment.NewLine}");
                Console.ForegroundColor = NormalColor;

                while ((line = inputFile.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                    {
                        // forgive them their sins...
                        continue;
                    }

                    result.Add(line.Trim());
                }

                inputFile.Close();
            }

            return result;
        }
    }
}
