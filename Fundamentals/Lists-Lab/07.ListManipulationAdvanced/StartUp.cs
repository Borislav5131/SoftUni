using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            bool isChange = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] input = line.Split();

                string command = input[0];

                if (command == "Contains")
                {
                    int number = int.Parse(input[1]);

                    if (nums.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command == "PrintEven")
                {
                    PrintEvenNums(nums);
                }
                else if (command == "PrintOdd")
                {
                    PrintOddNums(nums);
                }
                else if (command == "GetSum")
                {
                    Console.WriteLine(GetSumOfNums(nums));
                }
                else if (command == "Filter")
                {
                    string condition = input[1];
                    int number = int.Parse(input[2]);

                    FilterNums(nums, condition, number);

                }

                isChange = true;

            }

            if (!isChange)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }

        private static void FilterNums(List<int> nums, string condition, int number)
        {
            List<int> filterNum = new List<int>();

            if (condition == "<")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] < number)
                    {
                        filterNum.Add(nums[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] > number)
                    {
                        filterNum.Add(nums[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] >= number)
                    {
                        filterNum.Add(nums[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] <= number)
                    {
                        filterNum.Add(nums[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", filterNum));
        }

        private static int GetSumOfNums(List<int> nums)
        {
            int sum = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        private static void PrintOddNums(List<int> nums)
        {
            List<int> oddNums = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    oddNums.Add(nums[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oddNums));
        }

        private static void PrintEvenNums(List<int> nums)
        {
            List<int> evenNums = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums.Add(nums[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenNums));
        }
    }
}
