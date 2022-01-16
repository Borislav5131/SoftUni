using System;

namespace _06.Building
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int flors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = flors; i >= 1; i--)
            {
                for (int k = 0; k <= rooms; k++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($"О{i}{k} ");
                    }
                    else
                    {
                        Console.Write($"А{i}{k} ");
                    }
                    if (i == 1)
                    {
                        Console.Write($"L{i}{k} ");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
