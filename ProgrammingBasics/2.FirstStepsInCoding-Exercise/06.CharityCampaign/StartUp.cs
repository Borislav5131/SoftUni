using System;

namespace _06.CharityCampaign
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int daysForCampaign = int.Parse(Console.ReadLine());
            int numberOfCookers = int.Parse(Console.ReadLine());
            int countOfCakes = int.Parse(Console.ReadLine());
            int countOfWaffles = int.Parse(Console.ReadLine());
            int countOfPancakes = int.Parse(Console.ReadLine());

            double priceForCake = 45;
            double priceForWaffle = 5.80;
            double priceForPancakes = 3.20;

            double cakesFromCooker = countOfCakes * priceForCake;
            double wafflesFromCooker = countOfWaffles * priceForWaffle;
            double pancakesFromCooker = countOfPancakes * priceForPancakes;
            double sumForDay = (cakesFromCooker + wafflesFromCooker + pancakesFromCooker) * numberOfCookers;
            double sumForWholeCompaign = sumForDay * daysForCampaign;
            double finalSum = sumForWholeCompaign - (sumForWholeCompaign /8);

            Console.WriteLine(finalSum);

        }
    }
}
