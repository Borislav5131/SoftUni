using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split();
                string name = command[0];

                if (command.Length == 3)
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else if (command.Length == 4)
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
