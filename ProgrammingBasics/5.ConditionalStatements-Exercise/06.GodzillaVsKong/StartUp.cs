using System;

namespace _06.GodzillaVsKong
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceForClothes = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double sumForClothes = statists * priceForClothes;
            if (statists > 150)
            {
                sumForClothes -= (sumForClothes * 0.1);
            }
            double totalSum = decor + sumForClothes;

            if (budget >= totalSum )
            {
                double moneyLeft = budget - totalSum;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
            else if (budget < totalSum)
            {
                double neededMoney = totalSum - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");
            }
            
        }
    }
}
