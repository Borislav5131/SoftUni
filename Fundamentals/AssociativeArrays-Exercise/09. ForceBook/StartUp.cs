using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> forceBook = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    forceBook.Add(forceSide, new List<string>());

                    if (!forceBook[forceSide].Contains(forceUser))
                    {
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            foreach (var side in forceBook)
                            {
                                if (!side.Value.Contains(forceUser))
                                {
                                    side.Value.Add(forceUser);
                                    kvp.Value.Remove(forceUser);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            forceBook[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                    }

                }
            }

            foreach (var kvp in forceBook)
            {
                kvp.Value
                    .OrderByDescending(x => kvp.Value.Count)
                    .ThenBy(x => kvp.Value);
            }

            foreach (var kvp in forceBook)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var name in kvp.Value)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}
