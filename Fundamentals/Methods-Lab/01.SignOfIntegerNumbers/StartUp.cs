using System;

namespace _01.SignOfIntegerNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SignOfIntegerNumbers(n);
        }

        static void SignOfIntegerNumbers(int n)
        {
            if (n == 0)
            {
                Console.WriteLine("The number 0 is zero.");
            }
            else if (n < 0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }
            else if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
        }
    }
}
