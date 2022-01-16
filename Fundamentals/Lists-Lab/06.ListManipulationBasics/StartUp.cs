using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] input = line.Split();

                string command = input[0];
                int number = int.Parse(input[1]);

                if (command == "Add")
                {
                    nums.Add(number);
                }
                else if (command == "Remove")
                {
                    nums.Remove(number);
                }
                else if (command == "RemoveAt")
                {
                    int index = number;
                    nums.RemoveAt(index);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(input[2]);
                    nums.Insert(index, number);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
