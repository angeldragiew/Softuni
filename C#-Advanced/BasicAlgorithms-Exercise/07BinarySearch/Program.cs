using System;
using System.Linq;

namespace _07BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());

            int index = BinarySearch.IndexOf(arr, key);
            Console.WriteLine(index);
        }

        public class BinarySearch
        {
            public static int IndexOf(int[] arr, int key)
            {
                int left = 0;
                int right = arr.Length - 1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (key < arr[mid])
                    {
                        right = mid - 1;
                    }
                    else if (key > arr[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return -1;
            }
        }
    }
}
