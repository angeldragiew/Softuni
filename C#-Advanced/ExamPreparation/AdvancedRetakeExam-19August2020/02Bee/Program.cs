using System;

namespace Bee
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] field = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowData[col].ToString();
                }
            }
            int pollinatedFlowers = 0;
            int[] beePosition = FindBeePostion(field);
            int currRow = beePosition[0];
            int currCol = beePosition[1];
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                field[currRow, currCol] = ".";
                beePosition = Move(command, currRow, currCol);
                currRow = beePosition[0];
                currCol = beePosition[1];

                GoCheck:
                if (IsValidIndex(field, currRow, currCol))
                {
                    if (field[currRow, currCol] == "f")
                    {
                        pollinatedFlowers++;
                    }
                    else if (field[currRow, currCol] == "O")
                    {
                        field[currRow, currCol] = ".";
                        beePosition = Move(command, currRow, currCol);
                        currRow = beePosition[0];
                        currCol = beePosition[1];
                        goto GoCheck;
                    }
                    field[currRow, currCol] = "B";
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }             
            }
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            PrintField(field);
        }

        static void PrintField(string[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }

        static int[] Move(string direction, int row, int col)
        {
            int[] newPosition = new int[2];
            if (direction == "up")
            {
                row--;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "right")
            {
                col++;
            }
            newPosition[0] = row;
            newPosition[1] = col;
            return newPosition;
        }

        static bool IsValidIndex(string[,] field, int row, int col)
        {
            if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static int[] FindBeePostion(string[,] field)
        {
            int[] position = new int[2];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "B")
                    {
                        position[0] = row;
                        position[1] = col;
                        break;
                    }
                }
            }
            return position;
        }
    }
}
