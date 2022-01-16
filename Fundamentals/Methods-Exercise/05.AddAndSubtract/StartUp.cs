using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = Subtract(num1, num2, num3);

            Console.WriteLine(result);
        }
        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
        static int Subtract(int num1, int num2, int num3)
        {
            return Sum(num1, num2) - num3;
        }
    }
}
