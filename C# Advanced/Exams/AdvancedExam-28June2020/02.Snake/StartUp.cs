using System;

namespace _02.Snake
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;
            int burrow1Row = -1;
            int burrow1Col = -1;
            int burrow2Row = -1;
            int burrow2Col = -1;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        burrow2Row = row;
                        burrow2Col = col;

                    }
                }
            }

            if (burrow2Row != -1 && burrow2Col != -1)
            {
                matrix[burrow2Row, burrow2Col] = '-';

                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            burrow1Row = row;
                            burrow1Col = col;
                        }
                    }
                }

                matrix[burrow2Row, burrow2Col] = 'B';
            }

            int eatenFood = 0;

            while (eatenFood < 10)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow--;
                        break;
                    case "down":
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow++;
                        break;
                    case "left":
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol--;
                        break;
                    case "right":
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol++;
                        break;
                }

                if (snakeRow < 0 || snakeRow >= matrix.GetLength(0) ||
                    snakeCol < 0 || snakeCol >= matrix.GetLength(1))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    eatenFood++;
                    matrix[snakeRow, snakeCol] = '.';
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                    {
                        snakeRow = burrow2Row;
                        snakeCol = burrow2Col;
                        matrix[snakeRow, snakeCol] = 'S';
                    }
                    else if (snakeRow == burrow2Row && snakeCol == burrow2Col)
                    {
                        snakeRow = burrow1Row;
                        snakeCol = burrow1Col;
                        matrix[snakeRow, snakeCol] = 'S';
                    }
                }
            }

            if (eatenFood >= 10)
            {
                matrix[snakeRow, snakeCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {eatenFood}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
