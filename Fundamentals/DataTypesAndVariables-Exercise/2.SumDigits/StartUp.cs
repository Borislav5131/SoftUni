using System;

namespace _2.SumDigits
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            while (num >0)
            {
                int lastDigits = num % 10;
                sum += lastDigits;
                num /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
