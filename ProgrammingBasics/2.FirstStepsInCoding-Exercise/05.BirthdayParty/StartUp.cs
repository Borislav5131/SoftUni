using System;

namespace _05.BirthdayParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double rentForHall = double.Parse(Console.ReadLine());

            double priceForCake = rentForHall * 0.2;
            double priceForDrinks = priceForCake - (priceForCake * 0.45);
            double priceForAnimator = rentForHall / 3;

            double neededSum = rentForHall + priceForCake + priceForDrinks + priceForAnimator;

            Console.WriteLine(neededSum);

        }
    }
}
