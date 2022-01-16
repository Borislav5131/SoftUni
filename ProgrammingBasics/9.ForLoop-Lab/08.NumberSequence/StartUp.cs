using System;

namespace _08.NumberSequence
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int smallerNum = int.MaxValue;
            int biggestNum = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (biggestNum < numbers)
                {
                    biggestNum = numbers;
                }
                if (smallerNum > numbers)
                {
                    smallerNum = numbers;
                }
            }
            Console.WriteLine($"Max number: {biggestNum}");
            Console.WriteLine($"Min number: {smallerNum}");
        }
    }
}
