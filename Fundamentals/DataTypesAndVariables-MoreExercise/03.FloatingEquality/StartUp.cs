using System;

namespace _03.FloatingEquality
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double difference = Math.Abs(num1 * .00001);

            if (Math.Abs(num1 - num2) <= difference)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
