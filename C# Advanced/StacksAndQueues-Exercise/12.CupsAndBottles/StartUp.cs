using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            Queue<int> cupsCapacity = new Queue<int>(cups);
            Queue<int> bottlesFilled = new Queue<int>(bottles);

            int wastedWater = 0;

            while (cupsCapacity.Count > 0 || bottlesFilled.Count > 0)
            {
                int bottle = bottlesFilled.Dequeue();
                int cup = cupsCapacity.Peek();

                int fill = bottle - cup;

                if (bottle >= cup)
                {
                    cupsCapacity.Dequeue();
                    wastedWater += fill;
                }
                else if (bottle < cup)
                {
                    while (fill < cup)
                    {
                        if (bottlesFilled.Count > 0)
                        {
                            fill += bottlesFilled.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }

                    fill -= cup;
                    wastedWater += fill;
                    cupsCapacity.Dequeue();
                }
            }

            if (cupsCapacity.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }
            else if (bottlesFilled.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesFilled)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
