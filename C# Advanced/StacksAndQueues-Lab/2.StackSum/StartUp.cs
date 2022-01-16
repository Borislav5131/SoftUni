using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class StartUp
    {
        private static object stack;

        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(array);


            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .ToLower()
                    .Split();
                string command = tokens[0];

                if (command == "add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }
                else if (command == "remove")
                {
                    int count = int.Parse(tokens[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
