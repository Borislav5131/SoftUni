using System;

namespace _05.Time_15Minutes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 15;

            if (minutes > 59)
            {
                hour += 1;
                minutes -= 60;
                
            }
            if (hour > 23 )
            {
                hour = 0;
                hour += hour;
            }


            if (minutes < 10)
            {
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes}");
            }

            
            
        }
    }
}
