using System;

namespace _02.Selling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int meRow = -1;
            int meCol = -1;
            bool isContainPillars = false;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        meRow = row;
                        meCol = col;
                    }

                    if (matrix[row, col] == 'O')
                    {
                        isContainPillars = true;
                    }
                }
            }

            int pilar1Row = -1;
            int pilar1Col = -1;
            int pilar2Row = -1;
            int pilar2Col = -1;

            if (isContainPillars)
            {
                (pilar1Row, pilar1Col, pilar2Row, pilar2Col) = PillarsPositions(matrix, pilar1Row, pilar1Col, pilar2Row, pilar2Col);
            }

            int price = 0;
            bool isCollectMoney = false;
            bool isGoVoid = false;

            while (true)
            {
                if (price >= 50)
                {
                    isCollectMoney = true;
                    break;
                }

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        matrix[meRow, meCol] = '-';
                        meRow -= 1;
                        break;
                    case "down":
                        matrix[meRow, meCol] = '-';
                        meRow += 1;
                        break;
                    case "left":
                        matrix[meRow, meCol] = '-';
                        meCol -= 1;
                        break;
                    case "right":
                        matrix[meRow, meCol] = '-';
                        meCol += 1;
                        break;
                }

                if (meRow < 0 || meRow >= matrix.GetLength(0) ||
                    meCol < 0 || meCol >= matrix.GetLength(1))
                {
                    isGoVoid = true;
                    break;
                }

                if (char.IsDigit(matrix[meRow, meCol]))
                {
                    price += int.Parse(matrix[meRow, meCol].ToString());
                    matrix[meRow, meCol] = 'S';
                }
                else if (matrix[meRow, meCol] == 'O')
                {
                    if (meRow == pilar1Row && meCol == pilar1Col)
                    {
                        matrix[meRow, meCol] = '-';
                        meRow = pilar2Row;
                        meCol = pilar2Col;
                        matrix[meRow, meCol] = 'S';
                    }
                    else if (meRow == pilar2Row && meCol == pilar2Col)
                    {
                        matrix[meRow, meCol] = '-';
                        meRow = pilar1Row;
                        meCol = pilar1Col;
                        matrix[meRow, meCol] = 'S';
                    }
                }
            }

            if (isGoVoid)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            if (isCollectMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {price}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static (int pilar1Row, int pilar1Col, int pilar2Row, int pilar2Col) PillarsPositions(char[,] matrix, int pilar1Row, int pilar1Col, int pilar2Row, int pilar2Col)
        {
            bool isFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        pilar1Row = row;
                        pilar1Col = col;
                        matrix[pilar1Row, pilar1Col] = '-';
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        pilar2Row = row;
                        pilar2Col = col;
                    }
                }
            }

            matrix[pilar1Row, pilar1Col] = 'O';

            return (pilar1Row, pilar1Col, pilar2Row, pilar2Col);
        }
    }
}
