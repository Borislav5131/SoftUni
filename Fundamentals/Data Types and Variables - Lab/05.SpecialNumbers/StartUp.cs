using System;

namespace _05.SpecialNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int iOriginal = i;
                int lastDigits = 0;
                int sum = 0;

                while (iOriginal != 0)
                {
                    lastDigits = iOriginal % 10;
                    sum += lastDigits;
                    iOriginal /= 10;
                }


                if (sum == 5 ||
                    sum == 7 ||
                    sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
