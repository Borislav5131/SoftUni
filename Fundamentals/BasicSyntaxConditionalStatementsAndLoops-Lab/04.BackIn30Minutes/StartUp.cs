using System;

namespace _04.BackIn30Minutes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine()) + 30;

            if (min > 60)
            {
                hour++;
                min -= 60 ;
            }
            if (hour >= 24)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{min:d2}");
        }
    }
}
