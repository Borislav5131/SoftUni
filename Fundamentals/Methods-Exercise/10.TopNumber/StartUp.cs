using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            TopNum(n);
        }

        static void TopNum(int n)
        {
            for (int i = 1; i < n; i++)
            {
                bool isOdd = false;
                int original = i;
                int sumOfDigits = 0;

                while (i > 0)
                {
                    int lastDigit = i % 10;
                    sumOfDigits += lastDigit;

                    if (lastDigit % 2 != 0)
                    {
                        isOdd = true;
                    }

                    i /= 10;
                }

                i = original;

                if (sumOfDigits % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
