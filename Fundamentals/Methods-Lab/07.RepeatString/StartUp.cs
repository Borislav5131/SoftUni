using System;

namespace _07.RepeatString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string repeatedString = RepeatString(input, count);

            Console.WriteLine(repeatedString);
        }

        private static string RepeatString(string str, int count)
        {
            string newStr = "";

            for (int i = 1; i <= count; i++)
            {
                newStr += str;
            }

            return newStr;
        }
    }
}
