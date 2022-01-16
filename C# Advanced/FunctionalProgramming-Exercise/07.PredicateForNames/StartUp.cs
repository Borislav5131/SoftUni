using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .Where(x => x.Length <= n)
                .ToList();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
