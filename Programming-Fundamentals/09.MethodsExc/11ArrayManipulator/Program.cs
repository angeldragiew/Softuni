using System;
using System.Linq;
using System.Text;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //MaxEven(arr);
            //MaxOdd(arr);
            //MinEven(arr);
            //MinOdd(arr);
            FirstEven(arr, 3);

        }

        static void MaxEven(int[] arr)
        {
            int maxEven = int.MinValue;
            int index = 0;

            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] >= maxEven)
                {
                    maxEven = arr[i];
                    index = i;
                    found = true;
                }
            }
            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        static void MaxOdd(int[] arr)
        {
            int maxEven = int.MinValue;
            int index = 0;

            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1 && arr[i] >= maxEven)
                {
                    maxEven = arr[i];
                    index = i;
                    found = true;
                }
            }
            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        static void MinEven(int[] arr)
        {
            int minEven = int.MaxValue;
            int index = 0;

            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] <= minEven)
                {
                    minEven = arr[i];
                    index = i;
                    found = true;
                }
            }
            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        static void MinOdd(int[] arr)
        {
            int minOdd = int.MaxValue;
            int index = 0;

            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1 && arr[i] <= minOdd)
                {
                    minOdd = arr[i];
                    index = i;
                    found = true;
                }
            }
            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        static void FirstEven(int[] arr, int n)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            if (n > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        sb.Append(arr[i].ToString());
                        sb.Append(" ");
                        count++;
                    }
                }
            }

            string firstEven = sb.ToString();
            int[] evensArray = firstEven
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            
            if (count == 0)
            {
                Console.WriteLine("[]");
            }
            else if (count >= n)
            {
                int[] finalArray = new int[n];
                for (int i = 0; i < n; i++)
                {
                    finalArray[i] = evensArray[i];
                }
                Console.WriteLine($"[{string.Join(", ", finalArray)}]");
            }
            else
            {
                int[] finalArray = new int[count];
                for (int i = 0; i < count; i++)
                {
                    finalArray[i] = evensArray[i];
                }
                Console.WriteLine($"[{string.Join(", ", finalArray)}]");
            }
           
        }

        static void FirstOdd(int[] arr, int n)
        {
            StringBuilder sb = new StringBuilder();
            if (n > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        sb.Append(i.ToString());
                    }
                }
            }

        }
    }
}
