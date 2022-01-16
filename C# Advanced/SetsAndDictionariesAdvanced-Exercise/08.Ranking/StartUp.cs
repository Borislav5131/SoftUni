using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordForContest = new Dictionary<string, string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of contests")
                {
                    break;
                }

                string[] input = command.Split(":");

                passwordForContest.Add(input[0], input[1]);
            }

            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of submissions")
                {
                    break;
                }

                string[] input = command.Split("=>");
                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (passwordForContest.ContainsKey(contest) && passwordForContest[contest] == password)
                {
                    if (submissions.ContainsKey(username))
                    {
                        if (submissions[username].ContainsKey(contest))
                        {
                            if (points > submissions[username][contest])
                            {
                                submissions[username][contest] = points;
                            }
                        }
                        else
                        {
                            submissions[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                        submissions[username].Add(contest, points);
                    }
                }
            }

            string bestUser = "";
            int bestTotalPoints = 0;

            foreach (var user in submissions)
            {
                int totalPoints = 0;

                foreach (var contest in user.Value)
                {
                    totalPoints += contest.Value;
                }

                if (totalPoints > bestTotalPoints)
                {
                    bestTotalPoints = totalPoints;
                    bestUser = user.Key;
                }
            }


            Console.WriteLine($"Best candidate is {bestUser} with total {bestTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in submissions)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {

                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
