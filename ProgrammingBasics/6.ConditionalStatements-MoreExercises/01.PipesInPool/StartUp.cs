using System;

namespace _01.PipesInPool
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine()); 
            int debitFirstPipe = int.Parse(Console.ReadLine()); 
            int debitSecondPipe = int.Parse(Console.ReadLine());
            double hoursWorkerAbsent = double.Parse(Console.ReadLine());

            double waterFromFirstPipe = debitFirstPipe * hoursWorkerAbsent;
            double waterFromSecondPipe = debitSecondPipe * hoursWorkerAbsent;
            double amountOfWater = waterFromFirstPipe + waterFromSecondPipe;

            double percentage = (amountOfWater * 100) / poolVolume;
            double percentageFirstPipe = (waterFromFirstPipe * 100) / amountOfWater;
            double percentageSecondPipe = (waterFromSecondPipe * 100) / amountOfWater;

            if (amountOfWater <= poolVolume)
            {
                Console.WriteLine($"The pool is {percentage:f2} % full. Pipe 1: {percentageFirstPipe:f2}%. Pipe 2: {percentageSecondPipe:f2}%.");
            }
            else if (amountOfWater > poolVolume)
            {
                double overflowWater = (waterFromFirstPipe + waterFromSecondPipe) - poolVolume;
                Console.WriteLine($"For {hoursWorkerAbsent:f2} hours the pool overflows with {overflowWater:f2} liters.");
            }
        }
    }
}
