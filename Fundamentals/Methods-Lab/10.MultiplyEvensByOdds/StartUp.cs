using System;
using System.Linq;

namespace _10.MultiplyEvensByOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipleOfEvenAndOdds(num);

            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int num)
        {
            int evenSum = 0;
            int oddSum = 0;

            while (num > 0)
            {
                int lastDigit = num % 10;
                num /= 10;

                if (lastDigit % 2 == 0)
                {
                    evenSum += lastDigit;
                }
                else
                {
                    oddSum += lastDigit;
                }
            }

            return evenSum * oddSum;
        }
    }
}
