using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = lengths[0];
            int m = lengths[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            setOne = FillSet(setOne, n);
            setTwo = FillSet(setTwo, m);

            foreach (var num1 in setOne)
            {
                foreach (var num2 in setTwo)
                {
                    if (num1 == num2)
                    {
                        Console.Write($"{num1} ");
                    }
                }
            }
        }

         static HashSet<int> FillSet(HashSet<int> set, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int line = int.Parse(Console.ReadLine());
                set.Add(line);
            }

            return set;
        }
    }
}
