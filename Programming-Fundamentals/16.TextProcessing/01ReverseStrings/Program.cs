using System;
using System.Linq;

namespace _01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word!="end")
            {
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                string reverserdWord = new string(arr);

                Console.WriteLine($"{word} = {reverserdWord}");
                word = Console.ReadLine();
            }
        }
    }
}
