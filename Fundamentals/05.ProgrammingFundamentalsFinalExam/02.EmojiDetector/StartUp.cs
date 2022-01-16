using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Startup
    {
        static void Main(string[] args)
        {
            Regex regexEmoji = new Regex(@"([\:][\:]|[*][*])(?<emoji>[A-Z][a-z]{2,})\1");
            Regex regexNum = new Regex(@"(?<num>\d)");

            string input = Console.ReadLine();

            MatchCollection matchesEmojis = regexEmoji.Matches(input);
            MatchCollection matchesNums = regexNum.Matches(input);

            int threshold = 1;

            foreach (Match match in matchesNums)
            {
                threshold *= int.Parse(match.Value);

            }

            List<string> emojisFound = new List<string>();

            foreach (var item in matchesEmojis)
            {
                string emoji = item.ToString();
                int coolness = 0;

                foreach (var letter in emoji)
                {
                    coolness += (int)letter;
                }

                if (coolness >= threshold)
                {
                    emojisFound.Add(emoji);
                }
            }

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matchesEmojis.Count} emojis found in the text. The cool ones are:");

            foreach (var item in emojisFound)
            {
                Console.WriteLine(item);
            }
        }
    }
}
