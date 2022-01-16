using System;

namespace _08CinemaTicket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int output =0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    output = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    output = 14;
                    break;
                case "Saturday":
                case "Sunday":
                    output = 16;
                    break;
            }
            Console.WriteLine(output);
        }
    }
}
