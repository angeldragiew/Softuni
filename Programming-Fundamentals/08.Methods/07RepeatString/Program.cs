using System;
using System.Text;

namespace _07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repetition = int.Parse(Console.ReadLine());

            text = RepeatString(text, repetition);
            Console.WriteLine(text);
        }

        static string RepeatString(string text, int repetition)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= repetition; i++)
            {
                sb.Append(text);
            }
            text = sb.ToString();
            return text;
        }
    }
}
