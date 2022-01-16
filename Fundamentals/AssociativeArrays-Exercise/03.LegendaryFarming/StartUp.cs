using System;
using System.Collections.Generic;

namespace _03.LegendaryFarming
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("Shards", 0);
            keyMaterials.Add("Fragments", 0);
            keyMaterials.Add("Motes", 0);

            Dictionary<string, int> junk = new Dictionary<string, int>();

            while (keyMaterials["Shards"] < 250 ||
                keyMaterials["Fragments"] < 250 ||
                keyMaterials["Motes"] < 250)
            {
                string[] input = Console.ReadLine()
                .Split();

                for (int i = 0; i < input.Length; i++)
                {
                    int quantity = int.Parse(input[i]);
                    string name = input[i + 1];

                    if (keyMaterials.ContainsKey(name))
                    {
                        keyMaterials[name] += quantity;
                    }
                    else
                    {
                        junk.Add(name, quantity);
                    }
                }
            }

            string obatainItem = "";

            if (keyMaterials["Shards"] == 250)
            {
                obatainItem = "Shadowmourne";
                Console.WriteLine($"Shards obtained!");
            }
            else if (keyMaterials["Fragments"] == 250)
            {
                obatainItem = "Valanyr";
                Console.WriteLine($"Valanyr obtained!");
            }
            else if (keyMaterials["Motes"] == 250)
            {
                obatainItem = "Dragonwrath";
                Console.WriteLine($"Dragonwrath obtained!");
            }
        }
    }
}
