using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>\w+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            double totalPrice = 0;

            List<string> names = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                if (Regex.IsMatch(input,pattern))
                {
                    Match furniture = Regex.Match(input, pattern);

                    double price = double.Parse(furniture.Groups["price"].Value);
                    int quantity = int.Parse(furniture.Groups["quantity"].Value);

                    names.Add(furniture.Groups["name"].Value);

                    totalPrice += price * quantity;

                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine($"Bought furniture:");

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
