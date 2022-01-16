using System;

namespace _05.NeighborhoodShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());

            double sum = 0;

            if (town == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        sum = count * 0.50;
                        break;
                    case "water":
                        sum = count * 0.80;
                        break;
                    case "beer":
                        sum = count * 1.20;
                        break;
                    case "sweets":
                        sum = count * 1.45;
                        break;
                    case "peanuts":
                        sum = count * 1.60;
                        break;
                }
            }
            else if (town == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        sum = count * 0.40;
                        break;
                    case "water":
                        sum = count * 0.70;
                        break;
                    case "beer":
                        sum = count * 1.15;
                        break;
                    case "sweets":
                        sum = count * 1.30;
                        break;
                    case "peanuts":
                        sum = count * 1.50;
                        break;
                }
            }
            else if (town == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        sum = count * 0.45;
                        break;
                    case "water":
                        sum = count * 0.70;
                        break;
                    case "beer":
                        sum = count * 1.10;
                        break;
                    case "sweets":
                        sum = count * 1.35;
                        break;
                    case "peanuts":
                        sum = count * 1.55;
                        break;
                }
            }

            Console.WriteLine(Math.Round(sum, 4));
        }
    }
}
