using System;

namespace _02Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int currRow = 0;
            int currCol = 0;
            bool hasPillars = false;
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    if (field[row, col] == 'O')
                    {
                        hasPillars = true;
                    }
                }
            }

            int[] pillarsCoordinates = new int[4];
            int index = 0;
            if (hasPillars)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (field[row, col] == 'O')
                        {
                            pillarsCoordinates[index] = row;
                            pillarsCoordinates[index + 1] = col;
                            index += 2;
                        }
                    }
                }
            }

            int money = 0;

            bool hasCollectedEnoughMoney = true;
            while (money < 50)
            {
                string direction = Console.ReadLine();
                field[currRow, currCol] = '-';
                currRow = MoveRow(currRow, direction);
                currCol = MoveCol(currCol, direction);
                if(IsPositionValid(currRow, currCol, n, n) == false)
                {
                    hasCollectedEnoughMoney = false;
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                else if (field[currRow, currCol] == 'O')
                {
                    int firstPillarRow = pillarsCoordinates[0];
                    int firstPillarCol = pillarsCoordinates[1];
                    int secondPillarRow = pillarsCoordinates[2];
                    int secondPillarCol = pillarsCoordinates[3];

                    field[currRow, currCol] = '-';
                    if (currRow == firstPillarRow && currCol == firstPillarCol)
                    {
                        currRow = secondPillarRow;
                        currCol = secondPillarCol;
                    }
                    else
                    {
                        currRow = firstPillarRow;
                        currCol = firstPillarCol;
                    }
                }
                else if (field[currRow, currCol] == '-')
                {
                    field[currRow, currCol] = 'S';
                    continue;
                }
                else
                {
                    money += int.Parse(field[currRow, currCol].ToString());
                }

                field[currRow, currCol] = 'S';
            }

            if (hasCollectedEnoughMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
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
    }
}
