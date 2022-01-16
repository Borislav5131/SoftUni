using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            List<int> nums = new List<int>();

            for (int i = ranges[0]; i <= ranges[1] ; i++)
            {
                nums.Add(i);
            }

            nums = OddOrEven(nums,command);

            Console.WriteLine(string.Join(" ", nums));
        }
        static List<int> OddOrEven(List<int> nums, string command)
        {
            switch (command)
            {
                case "odd":
                    nums = nums
                        .Where(x => x % 2 != 0)
                        .ToList();
                    break;
                case "even":
                    nums = nums
                        .Where(x => x % 2 == 0)
                        .ToList();
                    break;
            }

            return nums;
        }
    }
}
