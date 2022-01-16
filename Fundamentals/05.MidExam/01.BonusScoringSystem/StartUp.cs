using System;

namespace _01.BonusScoringSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfStudent = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int theInitialBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int studentAttendace = 0;
            double totalBonus = 0;

            for (int i = 1; i <= countOfStudent; i++)
            {
                int attendancesForStudent = int.Parse(Console.ReadLine());

                totalBonus = (1.0 * attendancesForStudent / countOfLectures) * (5 + theInitialBonus);

                if (totalBonus >= maxBonus)
                {
                    maxBonus = totalBonus;
                    studentAttendace = attendancesForStudent;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendace} lectures.");
        }
    }
}
