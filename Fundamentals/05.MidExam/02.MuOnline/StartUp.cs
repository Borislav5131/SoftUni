using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoin = 0;

            string[] array = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int counter = 0;

            for (int i = 0; i <= array.Length - 1; i++)
            {
                string[] input = array[i].Split(" ");
                string command = input[0];
                int number = int.Parse(input[1]);

                if (command == "potion")
                {
                    if (health < 100)
                    {
                        int oldHealth = health;
                        if (health + number >= 100)
                        {
                            health = 100;
                        }
                        else
                        {
                            health += number;
                        }
                        int newHealth = health;

                        Console.WriteLine($"You healed for {newHealth - oldHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (command == "chest")
                {
                    bitcoin += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    health -= number;

                    if (health <= 0)
                    {
                        string monster = input[0];
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                    else
                    {
                        string monster = input[0];
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }

                counter++;
            }

            if (counter >= array.Length)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoin}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
