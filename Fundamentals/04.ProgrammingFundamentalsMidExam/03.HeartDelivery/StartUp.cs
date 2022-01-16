using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int position = 0;
            int counter = 0;
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Love!")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                position += int.Parse(commands[1]);

                if (position > houses.Count - 1)
                {
                    position = 0;
                }

                if (houses[position] == 0)
                {
                    Console.WriteLine($"Place {position} already had Valentine's day.");
                    continue;
                }
                else
                {
                    houses[position] -= 2;

                    if (houses[position] == 0)
                    {
                        Console.WriteLine($"Place {position} has Valentine's day.");
                    }
                }

            }

            Console.WriteLine($"Cupid's last position was {position}.");

            for (int i = 0; i < houses.Count; i++)
            {
                if (houses[i] == 0)
                {
                    counter++;
                }
            }

            if (counter == houses.Count)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Count - counter} places.");
            }
        }
    }
}
