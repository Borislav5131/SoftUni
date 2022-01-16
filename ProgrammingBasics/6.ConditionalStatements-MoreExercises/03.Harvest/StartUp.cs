using System;

namespace _03.Harvest
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int squareMetersOfVineyard = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int neededLitersWine = int.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());

            double totalGrapes = squareMetersOfVineyard * grapes;
            double wine = (totalGrapes * 0.4) / 2.5;

            if (wine >= neededLitersWine)
            {
                double leftWine =Math.Ceiling(wine - neededLitersWine);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor( wine)} liters.");
                double wineForOneWorker =Math.Ceiling(leftWine / countOfWorkers);
                Console.WriteLine($"{leftWine} liters left -> {wineForOneWorker} liters per person.");
            }
            else if (wine < neededLitersWine)
            {
                double neededWine =Math.Floor(neededLitersWine - wine);
                Console.WriteLine($"It will be a tough winter! More {neededWine} liters wine needed.");
            }
            
        }
    }
}
