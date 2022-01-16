using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(tokens);    
            }

            int petrolCounter = 0;

            while (true)
            {
                int[] parts = queue.Peek();

                int petrol = parts[0];
                int distance = parts[1];

                if (petrol >= distance)
                {
                    petrolCounter++;
                }
                else
                {

                }
            }
        }
    }
}
