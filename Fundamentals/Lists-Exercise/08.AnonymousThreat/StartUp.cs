using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> lst = Console.ReadLine()
                .Split()
                .ToList();
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] commands = input.Split();
                string command = commands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    MergeElement(lst, startIndex, endIndex);
                }
                else if (command == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);

                    DivideElement(lst, index, count);
                }
            }

            Console.WriteLine(string.Join(" ",lst));
        }

        private static void DivideElement(List<string> lst, int index, int count)
        {
            lst[index].Split();
        }

        private static void MergeElement(List<string> lst, int startIndex, int endIndex)
        {
            List<string> str = new List<string>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                str.Add(lst[i]);
                lst.RemoveAt(i);
            }

            
        }
    }
}
