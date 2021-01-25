using System;
using System.Linq;

namespace _9Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int row = 0; row < size; row++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];
                }
            }
            int coals = CoalsCount(field);
            int[] startCoordinates = FindStartCordinates(field);
            int currRow = startCoordinates[0];
            int currCol = startCoordinates[1];
            bool end = false;
            foreach (var direction in directions)
            {
                if (direction == "left" && ValidateCoordinates(currRow, currCol - 1, field))
                {
                    currCol -= 1;
                }
                else if (direction == "right" && ValidateCoordinates(currRow, currCol + 1, field))
                {
                    currCol += 1;
                }
                else if (direction == "up" && ValidateCoordinates(currRow - 1, currCol, field))
                {
                    currRow -= 1;
                }
                else if (direction == "down" && ValidateCoordinates(currRow + 1, currCol, field))
                {
                    currRow += 1;
                }

                if (field[currRow, currCol] == 'c')
                {
                    coals--;
                    field[currRow, currCol] = '*';
                }
                else if (field[currRow, currCol] == 'e')
                {
                    end = true;
                }
            }

            if (end)
            {
                Console.WriteLine($"Game over! {(currRow, currCol)}");
            }
            else if (coals > 0)
            {
                Console.WriteLine($"{coals} coals left. ({currRow}, {currCol})");
            }
            else if (coals == 0)
            {
                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
            }

        }

        public static int[] FindStartCordinates(char[,] field)
        {
            int[] startCoordinates = new int[2];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 's')
                    {
                        startCoordinates[0] = row;
                        startCoordinates[1] = col;
                    }
                }
            }
            return startCoordinates;
        }

        public static bool ValidateCoordinates(int row, int col, char[,] field)
        {
            bool isValid = false;

            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
        }

        public static int CoalsCount(char[,] field)
        {
            int counter = 0;
            foreach (var item in field)
            {
                if (item == 'c')
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int isCoalOrEnd(int row, int col, char[,] field, int coals)
        {
            if (field[row, col] == 'c')
            {
                coals--;
                return coals;
            }
            else if (field[row, col] == 'e')
            {
                return -1;
            }
            return coals;
        }

    }
}
