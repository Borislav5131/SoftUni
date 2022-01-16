using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<int, string>> submisions = new Dictionary<string, Dictionary<int, string>>();

            string bannedUser = "";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                string[] tokens = input.Split("-");
                string username = tokens[0];

                if (input.Contains("banned"))
                {
                    bannedUser = username;
                }
                else
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    submisions.Add(username, new Dictionary<int, string>());
                    submisions[username].Add(points, language);
                }
            }

            Dictionary<string, Dictionary<int, string>> sortedDic = submisions.OrderByDescending(x => x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x=> x.Value);

            Console.WriteLine("Results:");

            foreach (var kvp in submisions)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value.Keys}");
            }

            Console.WriteLine("Submissions:");
        }
    }
}
