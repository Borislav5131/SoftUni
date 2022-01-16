using System;

namespace _08.MathPower
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double degree = double.Parse(Console.ReadLine());

            double result = MathPower(num, degree);

            Console.WriteLine(result);
        }

        static double MathPower(double num, double degree)
        {
            double result = 1;

            for (int i = 1; i <= degree; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
