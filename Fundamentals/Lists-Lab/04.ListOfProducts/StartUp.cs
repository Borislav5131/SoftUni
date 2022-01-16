using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string product = Console.ReadLine();

                products.Add(product);
            }

            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
