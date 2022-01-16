using System;

namespace _07.FruitMarket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double priceOfStrawberries = double.Parse(Console.ReadLine());
            double countOfBananas = double.Parse(Console.ReadLine());
            double countOfOranges = double.Parse(Console.ReadLine());
            double countOfRaspberries = double.Parse(Console.ReadLine());
            double countOfStrawberries = double.Parse(Console.ReadLine());

            double priceOfRaspberries = priceOfStrawberries * 0.5;
            double priceOfOranges = priceOfRaspberries - (priceOfRaspberries * 0.4);
            double priceOfBananas = priceOfRaspberries - (priceOfRaspberries * 0.8);

            double sumOfRaspberries = countOfRaspberries * priceOfRaspberries;
            double sumOfOranges = countOfOranges * priceOfOranges;
            double sumOfBananas = countOfBananas * priceOfBananas;
            double sumOfStrawberries = countOfStrawberries * priceOfStrawberries;

            double totalSum = sumOfRaspberries + sumOfOranges + sumOfBananas + sumOfStrawberries;

            Console.WriteLine($"{totalSum:F2}");

        }
    }
}
