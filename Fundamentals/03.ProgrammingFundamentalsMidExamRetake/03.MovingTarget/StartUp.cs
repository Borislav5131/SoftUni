using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int index = int.Parse(commands[1]);

                if (commands[0] == "Shoot")
                {
                    int power = int.Parse(commands[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        if (targets[index] > power)
                        {
                            targets[index] -= power;
                        }
                        else
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (commands[0] == "Add")
                {
                    int value = int.Parse(commands[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (commands[0] == "Strike")
                {
                    int radius = int.Parse(commands[2]);

                    if (index + radius < targets.Count &&
                        index - radius >= 0)
                    {
                        targets.RemoveRange(index - radius, (index + radius) - (index - radius) + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
