using System;

namespace _10.PokeMon
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            int originalN = N;
            int count = 0;

            while (N >= M)
            {
                count++;
                N -= M;

                if (Y > 0)
                {

                    if (originalN / 2 == N)
                    {
                        N /= Y;
                    }
                }
            }

            Console.WriteLine(N);
            Console.WriteLine(count);
        }
    }
}
