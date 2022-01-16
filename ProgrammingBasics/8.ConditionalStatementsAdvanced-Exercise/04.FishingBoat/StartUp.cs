using System;

namespace _04.FishingBoat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const int shipPriceSpring = 3000;
            const int shipPriceSummerAndAutumn = 4200;
            const int shipPriceWinter = 2600;

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishermans = int.Parse(Console.ReadLine());

            double totalMoney = 0;

            switch (season)
            {
                case "Spring":
                    totalMoney = shipPriceSpring;
                    break;
                case "Summer":
                case "Autumn":
                    totalMoney =  shipPriceSummerAndAutumn;
                    break;
                case "Winter":
                    totalMoney =  shipPriceWinter;
                    break;
            }

            if (numberOfFishermans <= 6)
            {
                totalMoney -= totalMoney * 0.10;
            }
            else if (numberOfFishermans >= 7 && numberOfFishermans <= 11)
            {
                totalMoney -= totalMoney * 0.15;
            }
            else if (numberOfFishermans > 12)
            {
                totalMoney -= totalMoney * 0.25;
            }

            if (numberOfFishermans % 2 == 0 && season != "Autumn")
            {
                totalMoney -= totalMoney * 0.05;
            }

            if (budget >= totalMoney)
            {
                double moneyLeft = budget - totalMoney;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else if (budget < totalMoney)
            {
                double neededMoney = totalMoney - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva.");
            }
        }
    }
}
