using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> collection = new List<int>();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();
                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(secondItem);
                }
            }

            if (firstBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count <= 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int sumOfItems = 0;

            foreach (var item in collection)
            {
                sumOfItems += item;
            }

            if (sumOfItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfItems}");
            }
        }
    }
}
