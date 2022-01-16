using System;

namespace _01.SoftUniReception
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int totalEmployeeEficiens = firstEmployee + secondEmployee + thirdEmployee;
            int hour = 0;

            while (studentsCount > 0)
            {
                studentsCount -= totalEmployeeEficiens;
                hour += 1;

                if (hour % 4 == 0)
                {
                    hour++;
                }
            }

            Console.WriteLine($"Time needed: {hour}h.");
        }
    }
}
