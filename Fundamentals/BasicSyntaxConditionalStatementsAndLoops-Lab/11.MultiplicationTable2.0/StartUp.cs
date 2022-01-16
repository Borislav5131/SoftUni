using System;

namespace _10.MultiplicationTable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multipler = int.Parse(Console.ReadLine());
            int times = 10;
            int result = 0;

            if (multipler > 10)
            {
                result = number * multipler;
                Console.WriteLine($"{number} X {multipler} = {result}");
            }
            else
            {
                for (int i = multipler; i <= times; i++)
                {
                    result = number * i;
                    Console.WriteLine($"{number} X {i} = {result}");
                }
            }
        }
    }
}
