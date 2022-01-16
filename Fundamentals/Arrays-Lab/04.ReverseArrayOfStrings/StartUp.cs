using System;

namespace _04.ReverseArrayOfStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string oldElement = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = oldElement;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
