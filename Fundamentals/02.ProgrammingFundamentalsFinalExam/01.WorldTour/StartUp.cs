using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WorldTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(":");
                string command = tokens[0];

                if (command == "Travel")
                {
                    break;
                }
                else if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string str = tokens[2];

                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, str);
                    }

                    Console.WriteLine(input);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(input);
                }
                else if (command == "Switch")
                {
                    string oldstr = tokens[1];
                    string newstr = tokens[2];

                    if (input.Contains(oldstr))
                    {
                       input = input.Replace(oldstr, newstr);
                    }

                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
