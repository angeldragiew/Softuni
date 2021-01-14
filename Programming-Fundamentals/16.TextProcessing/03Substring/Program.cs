using System;

namespace _03Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int index = text.IndexOf(stringToRemove);

            while (index != -1)
            {
                text = text.Remove(index, stringToRemove.Length);
                index = text.IndexOf(stringToRemove);
            }
            Console.WriteLine(text);
        }
    }
}
