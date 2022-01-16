using System;

namespace _07.VendingMachine
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalMoney = 0;
            double sum = 0;

            while (input != "Start")
            {
                double coins = double.Parse(input);

                if (coins == 0.1 ||
                    coins == 0.2 ||
                    coins == 0.5 ||
                    coins == 1 ||
                    coins == 2)
                {
                    totalMoney += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    coins = 0;
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    sum += 2.0;
                }
                else if (product == "Water")
                {
                    sum += 0.7;
                }
                else if (product == "Crisps")
                {
                    sum += 1.5;
                }
                else if (product == "Soda")
                {
                    sum += 0.8;
                }
                else if (product == "Coke")
                {
                    sum += 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    break;
                }

                if (totalMoney >= sum)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum - totalMoney:f2}");
        }
    }
}
