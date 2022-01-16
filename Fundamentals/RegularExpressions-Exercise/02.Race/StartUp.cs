using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.Race
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            string[] line = Console.ReadLine().Split(", ");

            foreach (var person in line)
            {
                participants.Add(person, 0);
            }

            string namePattern = @"(?<name>[A-Za-z])";
            string distancePattern = @"\d";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                Match matchName = Regex.Match(input, namePattern);
                MatchCollection matchDistance = Regex.Matches(input, distancePattern);

                string name = matchName.Groups["name"].Value;
                int distance = 0;

                foreach (var km in matchDistance)
                {
                    int num = km.v
                }

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }
            }

            Dictionary<string, int> sortedDic = participants
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x=>x.Value);

            Console.WriteLine($"1st place: {sortedDic.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {sortedDic.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {sortedDic.Keys.ElementAt(2)}");
        }
    }
}
