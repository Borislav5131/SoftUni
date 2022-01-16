using System;

namespace _08.Scholarship
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarship =Math.Floor( minimalSalary * 0.35);
            double excellentScholarship =Math.Floor( averageSuccess * 25);

            if (income >= minimalSalary && averageSuccess >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income >= minimalSalary && averageSuccess < 5.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income < minimalSalary && averageSuccess > 5.5 && socialScholarship <= excellentScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income < minimalSalary && averageSuccess > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income < minimalSalary && averageSuccess <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }

            
        }
    }
}
