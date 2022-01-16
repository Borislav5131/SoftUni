using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AddVAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .ToList();

            Func<double, double> addVAT = number => number += 0.2 * number;

            foreach (var num in nums)
            {
                Console.WriteLine($"{addVAT(num):f2}");
            }
        }
    }
}
