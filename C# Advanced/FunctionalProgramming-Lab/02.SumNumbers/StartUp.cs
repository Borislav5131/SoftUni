using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SumNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(nums.Count);
            Console.WriteLine(nums.Sum());
        }
    }
}
