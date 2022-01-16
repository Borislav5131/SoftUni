using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(country))
                    {
                        continents[continent][country].Add(city);
                    }
                    else
                    {
                        continents[continent].Add(country, new List<string>() { city });
                    }

                }
                else
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(country, new List<string>() {city});
                }
            }

            foreach (var kvp in continents)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var kvp1 in kvp.Value)
                {
                    Console.WriteLine($"  {kvp1.Key} -> {string.Join(", ",kvp1.Value)}");
                }
            }
        }
    }
}
