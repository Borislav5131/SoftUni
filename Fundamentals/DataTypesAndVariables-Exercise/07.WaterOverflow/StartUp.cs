using System;

namespace _07.WaterOverflow
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int letters = int.Parse(Console.ReadLine());
                sum += letters;

                if (sum > tankCapacity )
                {
                    Console.WriteLine("Insufficient capacity!");
                    sum -= letters;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
