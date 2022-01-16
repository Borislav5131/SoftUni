using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> lst = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            SortedDictionary<int, int> numbers = new SortedDictionary<int, int>();

            foreach (int num in lst)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }

            foreach (var kvp in numbers)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
