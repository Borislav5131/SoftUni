using System;

namespace _01.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Recipe for one cozonac
            // Eggs - 1pack
            //Flour - 1kg
            //Milk - 0.250l

            double budget = double.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine()); //for 1kg

            double priceOfEggsPack = priceOfFlour * 0.75;
            double priceOfMilk = priceOfFlour + (priceOfFlour * 0.25); //1 liter
            double priceOfNeededMilk = priceOfMilk / 4;

            double totalPriceForOneCozonac = priceOfFlour + priceOfEggsPack + priceOfNeededMilk;

            int counterOfCozonacs = 0;
            int counterColoredEggs = 0;

            while (budget > 0)
            {
                if (budget < totalPriceForOneCozonac)
                {
                    break;
                }

                budget -= totalPriceForOneCozonac;
                counterOfCozonacs++;
                counterColoredEggs += 3;

                if (counterOfCozonacs % 3 == 0)
                {
                    counterColoredEggs -= counterOfCozonacs - 2;
                }
            }

            Console.WriteLine($"You made {counterOfCozonacs} cozonacs! Now you have {counterColoredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
