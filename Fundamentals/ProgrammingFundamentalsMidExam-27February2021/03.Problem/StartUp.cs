using System;
using System.Linq;

namespace _03.Problem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItem = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < entryPoint)
                {
                    leftSum += nums[i];
                }
                else if (i > entryPoint)
                {
                    rightSum += nums[i];
                }
            }

            int highSum = 0;
            int lowSum = 0;
            string sideHight = "";
            string sideLow = "";

            if (leftSum > rightSum)
            {
                highSum = leftSum;
                sideHight = "Left";
                lowSum = rightSum;
                sideLow = "Right";
            }
            else if (rightSum > leftSum)
            {
                highSum = rightSum;
                sideHight = "Right";
                lowSum = leftSum;
                sideLow = "Left";
            }
            else
            {
                highSum = leftSum;
                lowSum = leftSum;
                sideLow = "Left";
                sideHight = "Left";
            }


            if (typeOfItem == "cheap")
            {
                Console.WriteLine($"{sideLow} - {lowSum}");
            }
            else if (typeOfItem == "expensive")
            {
                Console.WriteLine($"{sideHight} - {highSum}");
            }
        }
    }
}
