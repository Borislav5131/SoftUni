using System;

namespace _9.Volleyball
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string typeOfYear = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsHometown = double.Parse(Console.ReadLine());

            double weekendsInSofia = (48 - weekendsHometown) * 3 / 4;
            double holidayGamesInSofia = holidays * 2 / 3;
            double totalGames = weekendsInSofia + holidayGamesInSofia + weekendsHometown;

            switch (typeOfYear)
            {
                case "leap":
                    totalGames += totalGames * 0.15;
                    break;
            }

            Console.WriteLine(Math.Floor(totalGames));
        }
    }
}
