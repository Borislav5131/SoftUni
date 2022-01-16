using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> lst = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                string[] array = lst[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int k = 0; k < array.Length; k++)
                {
                    Console.Write($"{array[k]} ");
                }
            }
        }
    }
}
