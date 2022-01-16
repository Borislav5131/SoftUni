using System;

namespace _05.Firm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workersOvertime = int.Parse(Console.ReadLine());

            double hoursForDays = days * 8;
            double workingHours = hoursForDays - (hoursForDays * 0.1);
            double overtimeWork = workersOvertime * (2 * days);
            double totalTime =Math.Floor(workingHours + overtimeWork);

            if (totalTime >= neededHours)
            {
                double leftTime = totalTime - neededHours;
                Console.WriteLine($"Yes!{leftTime} hours left.");
            }
            else if (totalTime < neededHours)
            {
                double neededTime = neededHours - totalTime;
                Console.WriteLine($"Not enough time!{neededTime} hours needed.");
            }
        }
    }
}
