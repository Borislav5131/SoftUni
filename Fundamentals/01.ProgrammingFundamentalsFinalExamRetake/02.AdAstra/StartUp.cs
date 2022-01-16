using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([|#])(?<item>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>[0-9][0-9][0-9][0-9]?|10000)\1");

            string line = Console.ReadLine();

            MatchCollection matches = regex.Matches(line);

            int totalColories = 0;

            foreach (Match match in matches)
            {
                totalColories += int.Parse(match.Groups["calories"].Value);
            }

            int days = totalColories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match1 in matches)
            {
                string name = match1.Groups["item"].Value;
                string date = match1.Groups["date"].Value;
                int calories = int.Parse(match1.Groups["calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
