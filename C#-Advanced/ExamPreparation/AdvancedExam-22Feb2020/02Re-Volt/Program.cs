using System;

namespace _02Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());

            int carRow = 0;
            int carCol = 0;

            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col] == 'f')
                    {
                        carRow = row;
                        carCol = col;
                    }
                }
            }
            bool isWon = false;
            for (int i = 0; i < commandCount; i++)
            {
                string command = Console.ReadLine();

                int newCarRow = MoveRow(carRow, command);
                int newCarCol = MoveCol(carCol, command);
                ifCheck:
                if (IsPositionValid(newCarRow, newCarCol, n, n) == false)
                {
                    if (newCarRow < 0)
                    {
                        newCarRow = n - 1;
                    }
                    else if (newCarRow >= n)
                    {
                        newCarRow = 0;
                    }
                    else if (newCarCol < 0)
                    {
                        newCarCol = n - 1;
                    }
                    else if (newCarCol >= n)
                    {
                        newCarCol = 0;
                    }
                    goto ifCheck;
                }
                else if (field[newCarRow, newCarCol] == 'F')
                {
                    field[carRow, carCol] = '-';
                    field[newCarRow, newCarCol] = 'f';
                    isWon = true;
                    Console.WriteLine("Player won!");
                    break;
                }
                else if (field[newCarRow, newCarCol] == 'T')
                {
                    continue;
                }
                else if (field[newCarRow, newCarCol] == 'B')
                {
                    newCarRow = MoveRow(newCarRow, command);
                    newCarCol = MoveCol(newCarCol, command);
                    goto ifCheck;
                }
                field[carRow, carCol] = '-';
                carRow = newCarRow;
                carCol = newCarCol;
                field[carRow, carCol] = 'f';
            }
            if (isWon == false)
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row, col]);
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
