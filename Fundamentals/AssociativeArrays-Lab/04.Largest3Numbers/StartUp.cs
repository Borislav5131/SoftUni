using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Dictionary<int, int> biggestNums = new Dictionary<int, int>();

            int n = 3;

            if (nums.Count < 3)
            {
                n = nums.Count;
            }

            for (int i = 1; i <= n; i++)
            {
                int biggestNum = int.MinValue;

                for (int k = 0; k < nums.Count; k++)
                {
                    if (nums[k] > biggestNum)
                    {
                        biggestNum = nums[k];
                    }
                }


                biggestNums.Add(biggestNum, 1);
                nums.Remove(biggestNum);
            }

            foreach (var kvp in biggestNums)
            {
                Console.Write($"{kvp.Key} ");
            }
        }
    }
}
