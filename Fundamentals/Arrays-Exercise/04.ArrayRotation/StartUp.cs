using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 1; i <= counter; i++)
            {
                int savedNum = array[0];

                for (int k = 0; k < array.Length - 1; k++)
                {
                    array[k] = array[k + 1];
                }

                array[array.Length - 1] = savedNum;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
