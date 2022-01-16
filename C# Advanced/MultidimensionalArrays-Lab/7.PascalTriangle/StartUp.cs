using System;

namespace _7.PascalTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = new int[row + 1];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = row + col;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jagged[row]));
            }
        }
    }
}
