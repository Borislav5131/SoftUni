using System;

namespace _04.VacationBooksList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfPages = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            double timeForReadBook = countOfPages / pagesForHour;
            double needHours = timeForReadBook / numberOfDays;

            Console.WriteLine(needHours);

        }
    }
}
