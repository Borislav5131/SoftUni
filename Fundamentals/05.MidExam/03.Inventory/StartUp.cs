using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Craft!")
                {
                    break;
                }

                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "Collect")
                {
                    string item = commands[1];

                    if (inventory.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        inventory.Add(item);
                    }
                }
                else if (commands[0] == "Drop")
                {
                    string item = commands[1];

                    if (inventory.Contains(item))
                    { 
                        inventory.Remove(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commands[0] == "Combine Items")
                {
                    string[] items = commands[1].Split(":",StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = items[0];
                    string newItem = items[1];

                    if (inventory.Contains(oldItem))
                    {
                        int index = inventory.IndexOf(oldItem);
                        inventory.Insert(index + 1, newItem);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commands[0] == "Renew")
                {
                    string item = commands[1];

                    if (inventory.Contains(item))
                    {
                        string renewItem = item;
                        inventory.Remove(item);
                        inventory.Add(renewItem);
                    }
                }
            }

            Console.Write(string.Join(", ", inventory));
        }
    }
}
