using System;

namespace _4.SymbolInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isOccur = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char ch = matrix[row, col];

                    if (ch == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isOccur = true;
                    }
                }
            }

            if (!isOccur)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
