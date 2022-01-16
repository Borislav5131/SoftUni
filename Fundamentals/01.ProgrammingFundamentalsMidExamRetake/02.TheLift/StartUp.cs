using System;
using System.Linq;

namespace _02.TheLift
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    wagons[i] += 4 - wagons[i];
                }
            }
        }
    }
}
