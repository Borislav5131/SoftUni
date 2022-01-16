using System;

namespace _07.ToyShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const double puzzelPrice = 2.60;
            const double talkingDollPrice = 3;
            const double teddyBearPrice = 4.10;
            const double minionPrice = 8.20;
            const double truckPrice = 2;

            double priceForExcursion = double.Parse(Console.ReadLine());
            int countOfPuzzel = int.Parse(Console.ReadLine());
            int countOfTalkingDoll = int.Parse(Console.ReadLine());
            int countOfTeddyBear = int.Parse(Console.ReadLine());
            int countOfMinion = int.Parse(Console.ReadLine());
            int countOfTruck = int.Parse(Console.ReadLine());

            double totalSum = puzzelPrice * countOfPuzzel + talkingDollPrice * countOfTalkingDoll + teddyBearPrice * countOfTeddyBear + minionPrice * countOfMinion + truckPrice * countOfTruck;
            double countOfToys = countOfPuzzel + countOfTalkingDoll + countOfTeddyBear + countOfMinion + countOfTruck;

            if (countOfToys >= 50)
            {
                double discount = totalSum * 0.25;
                totalSum -= discount;
            }

            double rent = totalSum * 0.1;
            double finalSum = totalSum - rent;

            if (finalSum >= priceForExcursion)
            {
                double moneyLeft = finalSum - priceForExcursion;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
                
            }
            else
            {
                double neededMoney = priceForExcursion - finalSum;
                Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
            }

        }
    }
}
