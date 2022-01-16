using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x=> x % 2 ==0)
                .OrderBy(x=>x)
                .ToList();

            Console.WriteLine(string.Join(", ",line));
        }
    }
}
