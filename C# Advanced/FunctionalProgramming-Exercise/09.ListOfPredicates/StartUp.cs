using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> results = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (IsDivisible(nums,i))
                {
                    results.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",results));
        }

        static bool IsDivisible(int[] nums, int number)
        {
            foreach (var num in nums)
            {
                if (number%num !=0)
                {
                    return false;
                    break;
                }
            }

            return true;
        }
    }
}
