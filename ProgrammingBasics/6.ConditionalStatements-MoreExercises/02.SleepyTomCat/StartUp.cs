using System;

namespace _02.SleepyTomCat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());

            double workingDays = 365 - daysOff;
            double playInWorkingDay = workingDays * 63;
            double playInDayOff = daysOff * 127;
            double totalTimeForPlay = playInDayOff + playInWorkingDay;

            if (30000 > totalTimeForPlay)
            {
                double norm = 30000 - totalTimeForPlay;
                double hours = Math.Floor(norm / 60);
                double minutes = norm - (hours * 60);
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
            else if (30000 < totalTimeForPlay)
            {
                double norm = totalTimeForPlay - 30000;
                double hours = Math.Floor(norm / 60);
                double minutes = norm - (hours * 60);
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }

        }
    }
}
