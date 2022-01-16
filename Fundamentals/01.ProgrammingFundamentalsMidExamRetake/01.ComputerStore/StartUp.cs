using System;

namespace _01.ComputerStore
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double taxes = 0;
            double totalPrice = 0;
            double finalPrice = 0;
            bool isCorrect = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "special")
                {
                    finalPrice += totalPrice + taxes;
                    finalPrice -= finalPrice * 0.1;
                    break;
                }
                else if (input == "regular")
                {
                    finalPrice += totalPrice + taxes;
                    break;
                }

                double priceOfProduct = double.Parse(input);

                if (priceOfProduct < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                else if (priceOfProduct == 0)
                {
                    Console.WriteLine("Invalid order!");
                }

                taxes += priceOfProduct * 0.2;
                totalPrice += priceOfProduct;
            }

            if (taxes == 0 ||
                totalPrice == 0 ||
                finalPrice == 0)
            {
                isCorrect = false;
                Console.WriteLine("Invalid order!");
            }

            if (isCorrect)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: { totalPrice:f2}$");
                Console.WriteLine($"Taxes: { taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {finalPrice:f2}$");
            }
        }
    }
}
