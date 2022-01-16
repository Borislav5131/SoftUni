using System;
using System.Linq;

namespace _02.Survivor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = char.Parse(input[col]);
                }
            }

            int currRow = -1;
            int currCol = -1;
            int meTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Find")
                {
                    currRow = int.Parse(tokens[1]);
                    currCol = int.Parse(tokens[2]);

                    if (IsValid(matrix, currRow, currCol))
                    {
                        if (matrix[currRow][currCol] == 'T')
                        {
                            meTokens++;
                            matrix[currRow][currCol] = '-';
                        }
                    }
                }
                else if (tokens[0] == "Opponent")
                {
                    currRow = int.Parse(tokens[1]);
                    currCol = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    currRow = int.Parse(tokens[1]);
                    currCol = int.Parse(tokens[2]);

                    if (IsValid(matrix, currRow, currCol))
                    {
                        if (matrix[currRow][currCol] == 'T')
                        {
                            opponentTokens++;
                            matrix[currRow][currCol] = '-';
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            switch (direction)
                            {
                                case "up":
                                    currRow--;
                                    break;
                                case "down":
                                    currRow++;
                                    break;
                                case "left":
                                    currCol--;
                                    break;
                                case "right":
                                    currCol++;
                                    break;
                            }

                            if (IsValid(matrix,currRow,currCol))
                            {
                                if (matrix[currRow][currCol] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[currRow][currCol] = '-';
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else if (tokens[0] == "Gong")
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));   
            }

            Console.WriteLine($"Collected tokens: {meTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static bool IsValid(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0)
            && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}
