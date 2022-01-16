using System;

namespace UsdToBgn
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());

            double rateOfUsd = 1.79549;

            double bgn = usd * rateOfUsd;

            Console.WriteLine(bgn);
        }
    }
}
