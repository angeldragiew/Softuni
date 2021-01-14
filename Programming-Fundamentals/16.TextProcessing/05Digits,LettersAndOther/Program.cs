using System;
using System.Text;

namespace _05Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder others = new StringBuilder();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if(Char.IsDigit(currChar))
                {
                    digits.Append(currChar);
                }
                else if (Char.IsLetter(currChar))
                {
                    letters.Append(currChar);
                }
                else
                {
                    others.Append(currChar);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
