using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([=|\/])([A-Z][A-Za-z]{2,})\1");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            int travelPoints = 0;

            List<string> destinations = new List<string>();

            foreach (Match match in matches)
            {
                destinations.Add(match.Groups[2].Value);
                int points = match.Groups[2].Value.Length;
                travelPoints += points;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
