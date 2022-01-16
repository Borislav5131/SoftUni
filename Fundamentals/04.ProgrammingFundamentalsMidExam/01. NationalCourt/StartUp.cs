using System;

namespace _01._NationalCourt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int firstEmploye = int.Parse(Console.ReadLine());
            int secondEmploye = int.Parse(Console.ReadLine());
            int thirdEmploye = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalEficiantOneHour = firstEmploye + secondEmploye + thirdEmploye;
            int countHour = 0;

            while (peopleCount > 0)
            {
                countHour++;

                if (countHour % 4 == 0)
                {
                    continue;
                }

                peopleCount -= totalEficiantOneHour;
            }

            Console.WriteLine($"Time needed: {countHour}h.");
        }
    }
}
