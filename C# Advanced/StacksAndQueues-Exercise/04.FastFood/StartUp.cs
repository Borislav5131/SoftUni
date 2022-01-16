using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int order = queue.Peek();

                if (totalFood >= order)
                {
                    totalFood -= order;
                    queue.Dequeue();
                }
                else if (totalFood < order || totalFood <= 0)
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
        }
    }
}
