using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToHashSet();

            Func<HashSet<int>, int> SmallestNumFromSet = num => num.Min();

            Console.WriteLine(SmallestNumFromSet(nums));
        }
    }
}
