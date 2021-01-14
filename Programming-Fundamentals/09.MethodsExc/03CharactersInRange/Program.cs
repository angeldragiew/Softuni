using System;
using System.Linq;

namespace _03CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharactersInRange(firstChar, secondChar);
        }

        static void CharactersInRange(char firstChar, char secondChar)
        {
            int start = 0;
            int end = 0;
            if(firstChar>= secondChar)
            {
                start = secondChar;
                end = firstChar;
            }
            else
            {
                start = firstChar;
                end = secondChar;
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
