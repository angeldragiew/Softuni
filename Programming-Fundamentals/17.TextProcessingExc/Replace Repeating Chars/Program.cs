using System;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length-1; i++)
            {
                char firstChar = text[i];
                char secondChar = text[i + 1];
                if (firstChar == secondChar)
                {
                    text = text.Remove(i+1,1);                 
                    i -= 1;
                }
            }

            Console.WriteLine(text);
        }
    }
}
