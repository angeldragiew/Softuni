using System;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currChar = text[i];
                char nextChar = text[i + 1];

                int indexToRemove = text.IndexOf(nextChar);

                if (currChar == '>' && Char.IsDigit(nextChar))
                {
                    int currStrentgh = int.Parse(nextChar.ToString());
                    while (currStrentgh > 0)
                    {
                        if (indexToRemove >= text.Length)
                        {
                            break;
                        }
                        if (text[indexToRemove] == '>')
                        {
                            int powerToAdd = int.Parse(text[indexToRemove+1].ToString());
                            currStrentgh += powerToAdd;
                            indexToRemove++;
                        }
                            text = text.Remove(indexToRemove, 1);
                            currStrentgh--;
                       
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
