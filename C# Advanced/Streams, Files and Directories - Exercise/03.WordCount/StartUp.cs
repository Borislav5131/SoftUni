using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            List<string> inputWords = File.ReadAllLines("words.txt").ToList();

            foreach (var word in inputWords)
            {
                words.Add(word, 0);
            }

            List<string> lines = File.ReadAllLines("text.txt").ToList();

            foreach (var line in lines)
            {
                string[] arr = line.Split().ToArray();

                foreach (var word in arr)
                {
                    word.ToLower();
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }

            }

            words = words
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            string result;

            File.WriteAllLines("../../../actualResults.txt", words.Select(x=> $"{x.Key} - {x.Value}").ToArray());
        }
    }
}
