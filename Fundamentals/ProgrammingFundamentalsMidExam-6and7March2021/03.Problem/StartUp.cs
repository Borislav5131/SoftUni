using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> quest = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                if (command == "Change")
                {
                    int paintingNumber = int.Parse(parts[1]);
                    int changeNumber = int.Parse(parts[2]);

                    if (quest.Contains(paintingNumber))
                    {
                        int index = quest.IndexOf(paintingNumber);
                        quest[index] = changeNumber;
                    }
                }
                else if (command == "Hide")
                {
                    int paintingNumber = int.Parse(parts[1]);

                    if (quest.Contains(paintingNumber))
                    {
                        quest.Remove(paintingNumber);
                    }
                }
                else if (command == "Switch")
                {
                    int paintingNumber = int.Parse(parts[1]);
                    int paintingNumber2 = int.Parse(parts[2]);

                    if (quest.Contains(paintingNumber) && quest.Contains(paintingNumber2))
                    {
                        int index = quest.IndexOf(paintingNumber);
                        int index2 = quest.IndexOf(paintingNumber2);
                        quest[index] = paintingNumber2;
                        quest[index2] = paintingNumber;
                    }
                }
                else if (command == "Insert")
                {
                    int place = int.Parse(parts[1]);
                    int paintingNumber = int.Parse(parts[2]);

                    if (place + 1 >= 0 && place + 1 < quest.Count)
                    {
                        quest.Insert(place + 1, paintingNumber);
                    }
                }
                else if (command == "Reverse")
                {
                     quest.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", quest));
        }
    }
}
