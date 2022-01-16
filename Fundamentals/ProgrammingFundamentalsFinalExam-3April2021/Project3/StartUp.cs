using System;
using System.Collections.Generic;
using System.Linq;

namespace Project3
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            int counter = 0;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Stop")
                {
                    break;
                }
                else if (command == "Like")
                {
                    string guest = tokens[1];
                    string meal = tokens[2];

                    if (guests.ContainsKey(guest))
                    {
                        if (!guests[guest].Contains(meal))
                        {
                            guests[guest].Add(meal);
                        }
                    }
                    else
                    {
                        guests.Add(guest, new List<string>());
                        guests[guest].Add(meal);
                    }
                }
                else if (command == "Unlike")
                {
                    string guest = tokens[1];
                    string meal = tokens[2];

                    if (guests.ContainsKey(guest))
                    {
                        if (guests[guest].Contains(meal))
                        {
                            guests[guest].Remove(meal);
                            counter++;

                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }
                
            }

            guests = guests
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x=>x.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            foreach (var kvp in guests)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }

            Console.WriteLine($"Unliked meals: {counter}");
        }
    }
}
