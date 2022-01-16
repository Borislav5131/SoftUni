using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> foods = new SortedDictionary<string, int>()
            {
                {"Bread",0},
                {"Cake",0},
                {"Pastry",0},
                {"Fruit Pie",0}
            };

            int[] inputLiquids = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            Stack<int> liquids = new Stack<int>();

            foreach (var num in inputLiquids)
            {
                liquids.Push(num);
            }

            int[] inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> ingredients = new Stack<int>();

            foreach (var num in inputIngredients)
            {
                ingredients.Push(num);
            }

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();


                if (liquid + ingredient == 25)
                {
                    foods["Bread"]++;
                    liquids.Pop();
                    ingredients.Pop();
                }
                else if (liquid + ingredient == 50)
                {
                    foods["Cake"]++;
                    liquids.Pop();
                    ingredients.Pop();
                }
                else if (liquid + ingredient == 75)
                {
                    foods["Pastry"]++;
                    liquids.Pop();
                    ingredients.Pop();
                }
                else if (liquid + ingredient == 100)
                {
                    foods["Fruit Pie"]++;
                    liquids.Pop();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Pop();
                    int num = ingredients.Pop();
                    num += 3;
                    ingredients.Push(num);
                }
            }

            if (foods["Bread"] > 0 && foods["Cake"] > 0 && foods["Pastry"] > 0 && foods["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var kvp in foods)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
