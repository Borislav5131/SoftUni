using System;

namespace _09.SpiceMustFlow
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int day = 0;
           
            while (startingYield >= 100)
            {
                day++;
                startingYield -= 10;
            }

            
        }
    }
}
