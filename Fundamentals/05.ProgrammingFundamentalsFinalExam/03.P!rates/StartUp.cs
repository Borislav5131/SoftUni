using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Town
    {
        public long Population { get; set; }
        public long Gold { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Town> towns = new Dictionary<string, Town>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sail")
                {
                    break;
                }

                string[] parts = input.Split("||");

                if (towns.ContainsKey(parts[0]))
                {
                    towns[parts[0]].Population += int.Parse(parts[1]);
                    towns[parts[0]].Gold += int.Parse(parts[2]);
                }
                else
                {
                    towns.Add(parts[0], new Town());
                    towns[parts[0]].Population = int.Parse(parts[1]);
                    towns[parts[0]].Gold = int.Parse(parts[2]);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split("=>");

                if (tokens[0] == "Plunder")
                {
                    towns[tokens[1]].Population -= int.Parse(tokens[2]);
                    towns[tokens[1]].Gold -= int.Parse(tokens[3]);

                    Console.WriteLine($"{tokens[1]} plundered! {tokens[3]} gold stolen, {tokens[2]} citizens killed.");

                    if (towns[tokens[1]].Population <= 0 ||
                        towns[tokens[1]].Gold <= 0)
                    {
                        towns.Remove(tokens[1]);

                        Console.WriteLine($"{tokens[1]} has been wiped off the map!");
                    }
                }
                else if(tokens[0] == "Prosper")
                {
                    if (int.Parse(tokens[2]) < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[tokens[1]].Gold += int.Parse(tokens[2]); 

                        Console.WriteLine($"{tokens[2]} gold added to the city treasury. {tokens[1]} now has {towns[tokens[1]].Gold} gold.");
                    }
                }
            }

            towns = towns.OrderByDescending(x => x.Value.Gold)
                .ThenBy(n => n.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            if (towns.Keys.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Keys.Count} wealthy settlements to go to:");

                foreach (var kvp in towns)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value.Population} citizens, Gold: {kvp.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
