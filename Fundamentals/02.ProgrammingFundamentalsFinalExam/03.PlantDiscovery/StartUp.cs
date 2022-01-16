using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Plant
    {
        public List<double> Rating { get; set; }
        public int Rarity { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");

                if (plants.ContainsKey(input[0]))
                {
                    plants[input[0]].Rarity = int.Parse(input[1]);
                }
                else
                {
                    plants.Add(input[0], new Plant());
                    plants[input[0]].Rarity = int.Parse(input[1]);
                    plants[input[0]].Rating = new List<double>();
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(": ");

                if (tokens[0] == "Exhibition")
                {
                    break;
                }
                else if (tokens[0] == "Rate")
                {
                    string str = tokens[1];
                    string[] parts = str.Split(" - ");
                    string plant = parts[0];
                    int rating = int.Parse(parts[1]);

                    plants[plant].Rating.Add(rating);

                }
                else if (tokens[0] == "Update")
                {
                    string str = tokens[1];
                    string[] parts = str.Split(" - ");
                    string plant = parts[0];
                    int newRarity = int.Parse(parts[1]);

                    plants[plant].Rarity = newRarity;
                }
                else if (tokens[0] == "Reset")
                {
                    string plant = tokens[1];

                    plants[plant].Rating.Clear();
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var kvp in plants)
            {
                double average = 0;

                if (kvp.Value.Rating.Count <= 0)
                {
                    average = 0;
                }
                else
                {

                    average = kvp.Value.Rating.Average();
                }

                kvp.Value.Rating.Clear();
                kvp.Value.Rating.Add(average);
            }

            plants = plants
                .OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Rating.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in plants)
            {
                double num = 0;

                foreach (var number in kvp.Value.Rating)
                {
                    num = number;
                }
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: {num:f2}");
            }
        }
    }
}
