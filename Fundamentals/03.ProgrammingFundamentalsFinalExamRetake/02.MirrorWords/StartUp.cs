using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.MirrorWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([@|#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                foreach (Match match in matches)
                {
                    string word1 = match.Groups["word1"].Value;
                    string word2 = match.Groups["word2"].Value;

                    string savedWord2 = word2;

                    var array = word2
                        .ToCharArray()
                        .Reverse()
                        .ToArray();

                    word2 = new string(array);

                    if (word1 == word2)
                    {
                        dic.Add(word1, savedWord2);
                    }
                }

                if (dic.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");

                    Console.Write(string.Join(", ", dic.Select(x => string.Join(" <=> ", x.Key, x.Value))));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");

                if (dic.Count <= 0)
                {
                    Console.WriteLine("No mirror words!");
                }
            }

        }
    }
}
