using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = 
                new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string command = tokens[0];

                if (command == "Revision")
                {
                    break;
                }

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (shops.ContainsKey(shop))
                {
                    shops[shop].Add(product, price);
                }
                else
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }

            }

                foreach (var kvp in shops)
                {
                    Console.WriteLine($"{kvp.Key}->");

                    foreach (var prod in kvp.Value)
                    {
                        Console.WriteLine($"Product: {prod.Key}, Price: {prod.Value}");
                    }
                }
        }
    }
}
