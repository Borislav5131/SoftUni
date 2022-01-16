using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < nums.Count - 1; i++)
            {
                nums[i] += nums[nums.Count - 1];
                nums.RemoveAt(nums.Count - 1);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
