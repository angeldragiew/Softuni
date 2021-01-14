using System;
using System.Text;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = string.Empty;
            //string result = GetMiddleChars(text); 
            if (text.Length % 2 == 0)
            {
                result = GetMiddleCharacterFromEvenString(text);
            }
            else
            {
                result = GetMiddleCharacterFromOddString(text);
            }
            Console.WriteLine(result);
        }

        static string GetMiddleChars(string text)
        {
            StringBuilder middleChars = new StringBuilder();
            double n = text.Length;
            if (text.Length % 2 == 0)
            {
                middleChars.Append(text[text.Length / 2 - 1]);
                middleChars.Append(text[text.Length / 2]);
                
            }
            else
            {
                n /= 2;
                n = Math.Floor(n);
                middleChars.Append(text[(int)n]);
            }
            return middleChars.ToString();
        }

        static string GetMiddleCharacterFromEvenString(string text)
        {
            int index = text.Length / 2;
            string chars = text.Substring(index - 1, 2);

            return chars;
        }

        static string GetMiddleCharacterFromOddString(string text)
        {
            int index = text.Length / 2;
            string chars = text.Substring(index, 1);

            return chars;
        }
    }
}
