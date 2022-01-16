using System;

namespace _06.Cake
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int area = a * b;
            int totalPieces = 0;

            string text = Console.ReadLine();
            while (text != "STOP")
            {
                int pieces = int.Parse(text);
                totalPieces += pieces;
                if (totalPieces > area)
                {
                    break;
                }
                text = Console.ReadLine();
            }
            if (totalPieces > area)
            {
                Console.WriteLine($"No more cake left! You need {totalPieces - area} pieces more.");
            }
            else
            {
                Console.WriteLine($"{area - totalPieces} pieces are left.");
            }
        }
    }
}
