using System;
using System.Linq;

namespace _04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] arr = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Reverse()  
            //    .ToArray();

            //Console.WriteLine(string.Join(" ", arr));

            Console.WriteLine(string.Join(" ",Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray()));
        }
    }
}
