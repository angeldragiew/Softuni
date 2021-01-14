using System;
using System.Linq;

namespace _06EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            
            bool isEqual = false;
            int index = 0;

            
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr.Length == 1){
                    isEqual = true;
                    break;
                }
                int leftSum = 0;
                int rightSum = 0;
                for (int z = i - 1; z >= 0; z--)
                {
                    leftSum += arr[z];
                }
                for (int y = i+1; y < arr.Length; y++)
                {
                    rightSum += arr[y];
                }
                if (rightSum == leftSum)
                {
                    isEqual = true;
                    index = i;
                }
               
            }
            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
