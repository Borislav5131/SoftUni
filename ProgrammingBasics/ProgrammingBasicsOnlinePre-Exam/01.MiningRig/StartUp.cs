using System;

namespace _01.MiningRig
{
    class Startup
    {
        static void Main(string[] args)
        {
            int priceForVideoCard = int.Parse(Console.ReadLine());
            int priceForCabels = int.Parse(Console.ReadLine());
            double electricity = double.Parse(Console.ReadLine());
            double incomeFromOneVideoCard = double.Parse(Console.ReadLine());

            double totalSumForVideoCards = priceForVideoCard * 13;
            double totalSumForCables = priceForCabels * 13;
            double totalSumForMachine = totalSumForVideoCards + totalSumForCables + 1000;
            double totalIncome = (incomeFromOneVideoCard - electricity) * 13;
            double daysForReturn = totalSumForMachine / totalIncome;

            Console.WriteLine($"{totalSumForMachine}");
            Console.WriteLine($"{Math.Ceiling(daysForReturn)}");
        }
    }
}
