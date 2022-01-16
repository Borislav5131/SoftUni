using System;

namespace _01.Train
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            int sumOfPeople = 0;

            for (int i = 0; i <= array.Length - 1; i++)
            {
                int number = int.Parse(Console.ReadLine());
                array[i] = number;
                sumOfPeople += array[i];
            }

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.WriteLine(sumOfPeople);

        }
    }
}
