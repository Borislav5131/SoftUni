using System;

namespace _04.Refactoring_PrimeChecker
{
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
{
                bool isPrime = true;
                for (int k = 2; k < i; k++)
{
                    if (i % k == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                string result = "";

                if (isPrime)
                {
                    result = "true";
                }
                else
                {
                    result = "false";
                }

                Console.WriteLine($"{i} -> {result}");
            }
        }
    }
}
