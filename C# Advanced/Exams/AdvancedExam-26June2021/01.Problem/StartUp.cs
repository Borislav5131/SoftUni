using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> freshnesses = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);

            while (ingredients.Count > 0 && freshnesses.Count > 0)
            {
                int ingredient = ingredients.Peek();
                int freshness = freshnesses.Peek();
                int sum = ingredient * freshness;

                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                    continue; ;
                }

                if (sum == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshnesses.Pop();
                }
                else if (sum == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshnesses.Pop();
                }
                else if (sum == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshnesses.Pop();
                }
                else if (sum == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshnesses.Pop();
                }
                else
                {
                    freshnesses.Pop();
                    ingredients.Dequeue();
                    ingredient += 5;
                    ingredients.Enqueue(ingredient);
                }
            }

            if (dishes["Dipping sauce"] > 0 && dishes["Green salad"] > 0 && dishes["Chocolate cake"] > 0 && dishes["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            dishes = dishes
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in dishes)
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
            }
        }
    }
}
