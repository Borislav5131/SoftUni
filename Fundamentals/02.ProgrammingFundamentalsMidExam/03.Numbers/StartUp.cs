using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class StartUp
    {
        private static object list;

        static void Main(string[] args)
        {
            List<int> lst = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double avg = lst.Average();
            int[] result = lst
                .Where(n => n > avg)
                .OrderByDescending(n => n)
                .Take(5)
                .ToArray();

            if (result.Length <= 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ",result));
            }
        }
    }
}
