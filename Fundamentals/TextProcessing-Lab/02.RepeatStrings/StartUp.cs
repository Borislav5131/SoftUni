using System;

namespace _02.RepeatStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                string word = input[i];

                for (int k = 1; k <= word.Length; k++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
