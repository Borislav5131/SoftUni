using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> cubes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Mort")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int value = int.Parse(commands[1]);

                if (commands[0] == "Add")
                {
                    cubes.Add(value);
                }
                else if (commands[0] == "Remove")
                {
                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (cubes[i] == value)
                        {
                            cubes.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (commands[0] == "Replace")
                {
                    int replament = int.Parse(commands[2]);

                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (cubes[i] == value)
                        {
                            cubes[i] = replament;
                            break;
                        }
                    }
                }
                else if (commands[0] == "Collapse")
                {
                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (cubes[i] < value)
                        {
                            cubes.RemoveAt(i);
                            i = 0;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", cubes));
        }
    }
}
