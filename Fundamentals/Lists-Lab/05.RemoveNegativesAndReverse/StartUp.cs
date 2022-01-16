using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.RemoveAt(i);
                    i -= 1;
                }
            }

            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
            }

            nums.Reverse();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
