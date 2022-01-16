using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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

                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split();
                string command = commands[0];

                if (command == "Add")
                {
                    int number = int.Parse(commands[1]);
                    nums.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    if (index >= nums.Count ||
                        index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    nums.Insert(index, number);
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= nums.Count ||
                        index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    nums.RemoveAt(index);
                }
                else if (command == "Shift")
                {
                    int count = int.Parse(commands[2]);

                    if (commands[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            nums.Add(nums[0]);
                            nums.RemoveAt(0);
                        }
                    }
                    else if (commands[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            nums.Insert(0, nums[nums.Count - 1]);
                            nums.RemoveAt(nums.Count - 1);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
