using System;

namespace _04.VegetableMarket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double priceOfVegetables = double.Parse(Console.ReadLine());
            double priceOfFruits = double.Parse(Console.ReadLine());
            int kilogramsOfVegetables = int.Parse(Console.ReadLine());
            int kilogramsOfFruits = int.Parse(Console.ReadLine());

            double sumOfVegetables = priceOfVegetables * kilogramsOfVegetables;
            double sumOFFruits = priceOfFruits * kilogramsOfFruits;
            double totalSumBgn = sumOFFruits + sumOfVegetables;
            double Usd = 1.94;
            double totalSumUsd = totalSumBgn / Usd;

            Console.WriteLine($"{totalSumUsd:f2}");

        }
    }
}
