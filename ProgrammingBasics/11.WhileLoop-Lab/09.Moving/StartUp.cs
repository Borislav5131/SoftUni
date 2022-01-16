using System;
using System.Threading;

namespace _09.Moving
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double volume = x * Y * h;
            int countOfBoxes = 0;
            bool haveSpace = true;

            while (input != "Done")
            {
                int boxes = int.Parse(input);
                countOfBoxes += boxes;

                if (countOfBoxes > volume)
                {
                    haveSpace = false;
                    break;
                }
                input = Console.ReadLine();
            }

            if (haveSpace)
            {
                double leftSpace = volume - countOfBoxes;
                Console.WriteLine($"{leftSpace} Cubic meters left.");
            }
            else
            {
                double neededSpace = Math.Abs(countOfBoxes - volume);
                Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
            }
        }
    }
}
