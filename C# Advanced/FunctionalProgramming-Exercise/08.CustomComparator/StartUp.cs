using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            Func<List<int>, int[]> evenFilter = num => num.Where(n => n % 2 == 0).ToArray();
            Func<List<int>, int[]> oddFilter = num => num.Where(n => n % 2 != 0).ToArray();

            var evenNums = evenFilter(nums).OrderBy(x=>x);
            var oddNums = oddFilter(nums).OrderBy(x => x);

            Console.WriteLine($"{string.Join(" ",evenNums)} {string.Join(" ",oddNums)}");
        }
    }
}
