using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class StartUp
    {
        static void Main(string[] args)
        {
               List<string> shopingList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Go Shopping!")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string item = commands[1];

                if (commands[0] == "Urgent")
                {
                    if (shopingList.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        shopingList.Insert(0, item);
                    }
                }
                else if (commands[0] == "Unnecessary")
                {
                    if (shopingList.Contains(item))
                    {
                        shopingList.Remove(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commands[0] == "Correct")
                {
                    string oldItem = commands[1];
                    string newItem = commands[2];

                    if (shopingList.Contains(oldItem))
                    {
                        int index = shopingList.IndexOf(oldItem);
                        shopingList.Remove(item);
                        shopingList.Insert(index, newItem);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (commands[0] == "Rearrange") 
                {
                    if (shopingList.Contains(item))
                    {
                        shopingList.Add(item);
                        shopingList.Remove(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", shopingList));
        }
    }
}
