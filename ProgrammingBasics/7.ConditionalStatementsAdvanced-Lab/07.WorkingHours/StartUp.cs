using System;

namespace _07.WorkingHours
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            string output = "";

            if (hours >= 10 && hours <= 18)
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        output = "open";
                        break;
                    case "Sunday":
                        output = "closed";
                        break;
                }
            }
            else
            {
                output = "closed";
            }

            Console.WriteLine(output);
        }
    }
}
