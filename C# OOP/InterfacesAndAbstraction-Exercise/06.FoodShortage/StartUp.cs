using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> all = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0],int.Parse(input[1]),input[2],input[3]);
                    all.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    all.Add(rebel);
                }
            }

            int totalFood = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var person in all)
                {
                    if (person.Name == command)
                    {
                        person.BuyFood();
                        totalFood += person.Food;
                        break;
                    }
                }
            }

            Console.WriteLine(totalFood);
        }
    }
}
