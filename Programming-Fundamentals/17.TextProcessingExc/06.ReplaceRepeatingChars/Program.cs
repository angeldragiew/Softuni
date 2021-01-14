using System;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == text[i + 1])
                {
                    text.Remove(text[i + 1]);
                    i = -1;
                }
            }

            Console.WriteLine(text);
        }
    }
}
