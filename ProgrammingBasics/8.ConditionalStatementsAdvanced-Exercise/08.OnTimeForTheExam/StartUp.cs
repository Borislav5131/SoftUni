using Microsoft.VisualBasic.CompilerServices;
using System;

namespace _08.OnTimeForTheExam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hoursOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minuteOfArrival = int.Parse(Console.ReadLine());

            int examTime = (hoursOfExam * 60) + minutesOfExam;
            int arrivalTime = (hourOfArrival * 60) + minuteOfArrival;
            int totalMinutesDifferent = arrivalTime - examTime;

            string studentArrivel = "Late";
            if (totalMinutesDifferent < -30)
            {
                studentArrivel = "Early";
            }
            else if (totalMinutesDifferent <= 30)
            {
                studentArrivel = "On time";
            }

            string result = string.Empty;
            if (totalMinutesDifferent != 0)
            {
                int hoursDifferent = Math.Abs(totalMinutesDifferent / 60);
                int minutesDifferent = Math.Abs(totalMinutesDifferent % 60);

                if (hoursDifferent > 0)
                {
                    result = string.Format("{0}:{1:00} hours", hoursDifferent, minutesDifferent);
                }
                else
                {
                    result = minutesDifferent + " minutes";
                }
                if (totalMinutesDifferent < 0)
                {
                    result += " before the start";
                }
                else
                {
                    result += " after the start";
                }
            }

            Console.WriteLine(studentArrivel);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }
    }
}
