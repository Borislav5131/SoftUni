using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class StartUp
    {
        private static object list;

        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bombNum = input[0];
            int power = input[1];

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == bombNum)
                {
                    if (i + power <= nums.Count)
                    {
                        nums.RemoveRange(i + 1, power);
                    }
                    else
                    {
                        nums.RemoveRange(i + 1, nums.Count - 1 - i);
                    }

                    if (i - power >= 0)
                    {
                        nums.RemoveRange(i - power, power);
                    }
                    else
                    {
                        nums.RemoveRange(0, nums.Count - 1 - i);
                    }

                    nums.Remove(bombNum);
                }
            }

            int sum = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }

            Console.WriteLine(sum);
        }
    }
}
