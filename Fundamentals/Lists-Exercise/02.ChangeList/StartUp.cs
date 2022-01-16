using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
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
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split();
                string command = commands[0];
                int number = int.Parse(commands[1]);

                if (command == "Delete")
                {
                    nums.Remove(number);
                }
                else if (command == "Insert")
                {
                    int position = int.Parse(commands[2]);

                    nums.Insert(position, number);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
