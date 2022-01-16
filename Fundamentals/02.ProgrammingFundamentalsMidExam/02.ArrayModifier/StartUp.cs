using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "swap")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);

                    int savedElement = array[index1];
                    array[index1] = array[index2];
                    array[index2] = savedElement;
                }
                else if (commands[0] == "multiply")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);

                    array[index1] *= array[index2];
                }
                else if (commands[0] == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
