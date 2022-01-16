using System;

namespace _07.WorldSwimmingRecord
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double range = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double timeForRange = range * time;
            double delay =Math.Floor(range / 15) * 12.5;
            double totalTime = timeForRange + delay;

            if (record <= totalTime)
            {
                double neededTime = totalTime - record;
                Console.WriteLine($"No, he failed! He was {neededTime:f2} seconds slower.");
            }
            else if (record > totalTime)
            { 
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }

        }
    }
}
