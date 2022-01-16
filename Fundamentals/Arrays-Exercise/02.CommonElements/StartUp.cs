using System;
using System.Linq;

namespace _02.CommonElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] secondArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (string item in secondArray)
            {
                if (firstArray.Contains(item))
                {
                    result += item;
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
