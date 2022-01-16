using System;

namespace _04.CenturiesToMinutes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int centurie = int.Parse(Console.ReadLine());

            int years = centurie * 100;
            int days = (int)(years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;

            Console.WriteLine($"{centurie} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
