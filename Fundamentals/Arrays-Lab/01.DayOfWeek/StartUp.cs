using System;

namespace _01.DayOfWeek
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] days =
                {"Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
                };

            int numberOfday = int.Parse(Console.ReadLine());

            if (numberOfday < 1 || numberOfday > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine($"{days[numberOfday - 1]}");
            }
        }
    }
}
