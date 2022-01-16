using System;

namespace _01.CounterStrike
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int countOfWins = 0;
            bool isWin = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End of battle")
                {
                    break;
                }

                int distance = int.Parse(input);


                if (initialEnergy <= 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {countOfWins} won battles and {initialEnergy} energy");
                    isWin = false;
                    break;
                }
                else if (initialEnergy > 0)
                {
                    countOfWins++;
                }

                initialEnergy -= distance;

                if (countOfWins % 3 == 0)
                {
                    initialEnergy += countOfWins;
                }

            }

            if (isWin)
            {
                Console.WriteLine($"Won battles: {countOfWins}. Energy left: {initialEnergy}");
            }
        }
    }
}
