using System;

namespace _08Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1 };
            int[] arr2 = arr1;
            arr2[0] = 2;
            Console.WriteLine(arr1[0]);
            Console.WriteLine(arr2[0]);

            string s1 = "A";
            string s2 = s1;
            s2 = "B";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }


    }
}
