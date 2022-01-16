using System;

namespace _02.WorkingOrHoliday
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();

            string output = "";

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    output = "Working day";
                    break;

                case "Saturday":
                case "Sunday":
                    output = "Weekend";
                    break;
                    
                default:
                    output = "Error";
                    break;
            }
            Console.WriteLine(output);
        }
    }
}
