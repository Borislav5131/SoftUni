using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();
                string productName = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (products.ContainsKey(productName))
                {
                    if (products[productName][0] != price)
                    {
                        products[productName][0] = price;
                    }

                    products[productName][1] += quantity;
                }
                else
                {
                    products.Add(productName, new List<double>() { price, quantity });
                    products[productName].Add(price);
                    products[productName].Add(quantity);

                }
            }

            foreach (var kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value[0] * kvp.Value[1]:f2}");
            }
        }
    }
}
