using System;

namespace _01.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double totalExperience = 0;

            for (int i = 1; i <= battlesCount; i++)
            {
                double earnedExperience = double.Parse(Console.ReadLine());

                totalExperience += earnedExperience;

                if (i % 3 ==0)
                {
                    totalExperience += earnedExperience * 0.15;
                }

                if (i % 5 == 0)
                {
                    totalExperience -= earnedExperience * 0.10;
                }
                if (i % 15 == 0)
                {
                    totalExperience += earnedExperience * 0.05;
                }

                if (totalExperience >= neededExperience)
                {
                    battlesCount = i;
                    break;
                }

            }

            if (totalExperience >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - totalExperience:f2} more needed.");
            }
        }
    }
}
