using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _02.KnightsOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Action<string> Printer = name => Console.WriteLine($"Sir {name}");

            foreach (var name in names)
            {
                Printer(name);
            }
        }
    }
}
