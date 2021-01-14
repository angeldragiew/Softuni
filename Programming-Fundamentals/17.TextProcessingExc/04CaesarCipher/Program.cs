using System;

namespace _04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string enryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                enryptedText += (char)(text[i] + 3);
            }

            Console.WriteLine(enryptedText);
        }
    }
}
