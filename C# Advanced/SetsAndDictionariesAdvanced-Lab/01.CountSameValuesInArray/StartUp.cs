using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countValues = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (countValues.ContainsKey(num))
                {
                    countValues[num]++;
                }
                else
                {
                    countValues.Add(num,1);
                }
            }

            foreach (var kvp in countValues)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
