using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallestNum = SmallestNumberOfThree(firstNum, secondNum, thirdNum);

            Console.WriteLine(smallestNum);
        }
        static int SmallestNumberOfThree(int num1, int num2, int num3)
        {
            int[] numbers = new int[3];
            numbers[0] = num1;
            numbers[1] = num2;
            numbers[2] = num3;

            int smallestNumber = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < smallestNumber)
                {
                    smallestNumber = numbers[i];
                }
            }

            return smallestNumber;
        }
    }
}
