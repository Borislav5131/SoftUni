using System;

namespace _06.Salary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string tabs = Console.ReadLine();

                if (tabs == "Facebook")
                {
                    salary -= 150;
                }
                else if (tabs == "Instagram")
                {
                    salary -= 100;
                }
                else if (tabs == "Reddit")
                {
                    salary -= 50;
                }
            }

            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
