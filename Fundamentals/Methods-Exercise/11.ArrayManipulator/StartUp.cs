using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] comand = line.Split();

                if (comand[0] == "exchange")
                {
                    int index = int.Parse(comand[1]);

                    ExchangeIndex(numbers, index);
                }
                else if (comand[0] == "max")
                {
                    if (comand[1] == "even")
                    {
                        MaxEvenNum(numbers);
                    }
                    else if (comand[1] == "odd")
                    {
                        MaxOddNum(numbers);
                    }
                }
                else if (comand[0] == "min")
                {
                    if (comand[1] == "even")
                    {
                        MinEvenNum(numbers);
                    }
                    else if (comand[1] == "odd")
                    {
                        MinOddNum(numbers);
                    }
                }
                else if (comand[0] == "first")
                {

                }
            }
        }

        private static void MinOddNum(int[] numbers)
        {
            int minOdd = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] < minOdd)
                    {
                        minOdd = numbers[i];
                    }
                }
            }

            if (minOdd == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
        }

        private static void MinEvenNum(int[] numbers)
        {
            int minEven = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] < minEven)
                    {
                        minEven = numbers[i];
                    }
                }
            }

            if (minEven == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
        }

        private static void MaxOddNum(int[] numbers)
        {
            int maxOdd = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] > maxOdd)
                    {
                        maxOdd = numbers[i];
                    }
                }
            }

            if (maxOdd == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
        }

        private static void MaxEvenNum(int[] numbers)
        {
            int maxEven = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] > maxEven)
                    {
                        maxEven = numbers[i];
                    }
                }
            }

            if (maxEven == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
        }

        private static void ExchangeIndex(int[] numbers, int index)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == index)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        int digit = numbers[k];
                        numbers[k] = numbers[numbers.Length - 1 - k];
                        numbers[numbers.Length - 1 - k] = digit;
                    }
                }
            }

            if (index > numbers.Length ||
                index < 0)
            {
                Console.WriteLine("Invalid index");
            }
        }
    }
}
