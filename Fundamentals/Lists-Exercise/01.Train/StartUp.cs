using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] commands = line.Split();
                string command = commands[0];

                if (command == "Add")
                {
                    int number = int.Parse(commands[1]);

                    wagons.Add(number);
                }
                else
                {
                    FitPassanger(wagons, line, maxCapacity);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FitPassanger(List<int> wagons, string line, int maxCapacity)
        {
            int num = int.Parse(line);

            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + num <= maxCapacity)
                {
                    wagons[i] += num;
                    return;
                }
            }
        }
    }
}
