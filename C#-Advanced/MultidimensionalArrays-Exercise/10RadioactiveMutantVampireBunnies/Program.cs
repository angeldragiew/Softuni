using System;
using System.Collections.Generic;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class Program
    {
        public static object SpreadBunnies { get; private set; }

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowSize = dimensions[0];
            int colSize = dimensions[1];
            char[,] field = new char[rowSize, colSize];

            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < rowSize; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < colSize; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            bool wonTheGame = false;
            bool died = false;

            int newPlayerRow = playerRow;
            int newPlayerCol = playerCol;
            foreach (var direction in directions)
            {
                if (direction == 'U')
                {
                    newPlayerRow -= 1;
                }
                else if (direction == 'D')
                {
                    newPlayerRow += 1;
                }
                else if (direction == 'L')
                {
                    newPlayerCol -= 1;
                }
                else if (direction == 'R')
                {
                    newPlayerCol += 1;
                }

                if (!ValidateCoordinates(newPlayerRow, newPlayerCol, field))
                {
                    wonTheGame = true;
                    field[playerRow, playerCol] = '.';
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    died = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<BunnyCoordinates> bunniesCoordinates = FindBunnieCoordinates(field);
                SpreadBunniess(bunniesCoordinates, field);
                if (field[playerRow, playerCol] != 'P')
                {
                    died = true;
                }

                if (wonTheGame)
                {
                    PrintField(field);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
                if (died)
                {
                    PrintField(field);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }

        }

        private static void SpreadBunniess(List<BunnyCoordinates> bunniesCoordinates, char[,] field)
        {
            foreach (var bunny in bunniesCoordinates)
            {
                int row = bunny.bunnyRow;
                int col = bunny.bunnyCol;
                if (ValidateCoordinates(row - 1, col, field))
                {
                    field[row - 1, col] = 'B';
                }
                if (ValidateCoordinates(row + 1, col, field))
                {
                    field[row + 1, col] = 'B';
                }
                if (ValidateCoordinates(row, col - 1, field))
                {
                    field[row, col - 1] = 'B';
                }
                if (ValidateCoordinates(row, col + 1, field))
                {
                    field[row, col + 1] = 'B';
                }
            }
        }

        private static List<BunnyCoordinates> FindBunnieCoordinates(char[,] field)
        {
            List<BunnyCoordinates> bunniesCoordinates = new List<BunnyCoordinates>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        BunnyCoordinates bunny = new BunnyCoordinates(row, col);
                        bunniesCoordinates.Add(bunny);
                    }
                }
            }

            return bunniesCoordinates;
        }

        private static bool ValidateCoordinates(int row, int col, char[,] field)
        {
            bool isValid = false;
            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }

        public static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        class BunnyCoordinates
        {
            public BunnyCoordinates(int row, int col)
            {
                bunnyRow = row;
                bunnyCol = col;
            }
            public int bunnyRow { get; set; }
            public int bunnyCol { get; set; }
        }
    }
}
