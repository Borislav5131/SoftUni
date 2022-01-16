using System;

namespace _10.MultiplicationTable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int times = 10;
            int result = 0;

            for (int i = 1; i <= times; i++)
            {
                result = number * i;
                Console.WriteLine($"{number} X {i} = {result}");
            }
        }
    }
}
