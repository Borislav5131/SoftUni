using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int> Add = num => num + 1;
            Func<int, int> Multiply = num => num * 2;
            Func<int, int> Subract = num => num - 1;
            Action<List<int>> Print = x => Console.WriteLine(string.Join(" ", x));

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = nums.Select(x=>Add(x)).ToList();
                        break;
                    case "multiply":
                        nums = nums.Select(x => Multiply(x)).ToList();
                        break;
                    case "subtract":
                        nums = nums.Select(x => Subract(x)).ToList();
                        break;
                    case "print":
                        Print(nums);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
