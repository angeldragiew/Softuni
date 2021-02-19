using System;
using System.Collections.Generic;

namespace _02Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            List<int> burrowCoordinates = new List<int>();

            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < n; row++)
            {
                string dataRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = dataRow[col];
                    if (field[row, col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    if (field[row, col] == 'B')
                    {
                        burrowCoordinates.Add(row);
                        burrowCoordinates.Add(col);
                    }
                }
            }
            int food = 0;
            while (food < 10)
            {
                field[currRow, currCol] = '.';
                string direction = Console.ReadLine();
                currRow = MoveRow(currRow, direction);
                currCol = MoveCol(currCol, direction);

                if (IsPositionValid(currRow, currCol, n, n) == false)
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                else if (field[currRow, currCol] == '*')
                {
                    food++;
                }
                else if (field[currRow, currCol] == 'B')
                {
                    int firstBurrowRow = burrowCoordinates[0];
                    int firstBurrowCol = burrowCoordinates[1];
                    int secondBurrowRow = burrowCoordinates[2];
                    int secondBurrowCol = burrowCoordinates[3];

                    if (currRow == firstBurrowRow && currCol == firstBurrowCol)
                    {
                        field[firstBurrowRow, firstBurrowCol] = '.';
                        currRow = secondBurrowRow;
                        currCol = secondBurrowCol;
                    }
                    else
                    {
                        field[secondBurrowRow, secondBurrowCol] = '.';
                        currRow = firstBurrowRow;
                        currCol = firstBurrowCol;
                    }
                }

                field[currRow, currCol] = 'S';
            }

            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
