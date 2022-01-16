using System;

namespace _08.GraduationPt._2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade = 1;
            double countOfEncluded = 0;
            double sumOfMark = 0;
            double avgMark = 0;
            bool isExclud = false;

            while (grade <= 12)
            {
                double mark = double.Parse(Console.ReadLine());
                if (mark < 4.00)
                {
                    countOfEncluded++;
                    if (countOfEncluded >= 1)
                    {
                        isExclud = true;
                        break;
                    }
                    continue;
                }
                grade++;
                sumOfMark += mark;
            }
            if (isExclud)
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            }
            else
            {
                avgMark = sumOfMark / 12;
                Console.WriteLine($"{name} graduated. Average grade: {avgMark:f2}");

            }
        }
    }
}
