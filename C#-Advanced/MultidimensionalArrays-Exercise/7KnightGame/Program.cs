using System;

namespace _7KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowData[col];
                }
            }


            int counter = 0;
            while (true)
            {
                int maxKnightAttackNumber = int.MinValue;
                int knigthAttackRow = -1;
                int knigthAttackCol = -1;
                int knightAttackNumber = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            knightAttackNumber = 0;
                            knightAttackNumber += LeftSideAttackNumber(row, col, board);
                            knightAttackNumber += RightSideAttackNumber(row, col, board);
                            knightAttackNumber += UpSideAttackNumber(row, col, board);
                            knightAttackNumber += DownSideAttackNumber(row, col, board);
                            if (knightAttackNumber > maxKnightAttackNumber)
                            {
                                maxKnightAttackNumber = knightAttackNumber;
                                knigthAttackRow = row;
                                knigthAttackCol = col;
                            }
                        }

                    }
                }

                if (maxKnightAttackNumber == 0)
                {
                    break;
                }
                if (maxKnightAttackNumber > 0)
                {
                    board[knigthAttackRow, knigthAttackCol] = '0';
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        public static int LeftSideAttackNumber(int row, int col, char[,] board)
        {
            int knightAttackNumber = 0;

            if (col - 2 >= 0 && row - 1 >= 0)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            if (col - 2 >= 0 && row + 1 < board.GetLength(0))
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            return knightAttackNumber;
        }

        public static int RightSideAttackNumber(int row, int col, char[,] board)
        {
            int knightAttackNumber = 0;

            if (col + 2 < board.GetLength(1) && row - 1 >= 0)
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            if (col + 2 < board.GetLength(1) && row + 1 < board.GetLength(0))
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            return knightAttackNumber;
        }

        public static int UpSideAttackNumber(int row, int col, char[,] board)
        {
            int knightAttackNumber = 0;

            if (col + 1 < board.GetLength(1) && row - 2 >= 0)
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            if (col - 1 >= 0 && row - 2 >= 0)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            return knightAttackNumber;
        }

        public static int DownSideAttackNumber(int row, int col, char[,] board)
        {
            int knightAttackNumber = 0;

            if (col + 1 < board.GetLength(1) && row + 2 < board.GetLength(0))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            if (col - 1 >= 0 && row + 2 < board.GetLength(0))
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    knightAttackNumber++;
                }
            }
            return knightAttackNumber;
        }
    }
}
