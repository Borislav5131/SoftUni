using System;

namespace Test1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine()) + 30;

            if (min > 60)
            {
                min -= 60;
                hour += 1;
            }

            if (hour >= 24)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{min:d2}");
        }
    }
}
