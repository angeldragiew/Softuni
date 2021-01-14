using System;
using System.Linq;

namespace _02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            string firstWord = words[0];
            string secondWord = words[1];

            CharMultiplier(firstWord, secondWord);

        }

        static void CharMultiplier(string firstWord, string secondWord)
        {
            int total = 0;
            int n = 0;

            if (firstWord.Length == secondWord.Length)
            {
                n = firstWord.Length;
            }
            else
            {
                if (firstWord.Length > secondWord.Length)
                {
                    n = secondWord.Length;
                    for (int i = secondWord.Length; i < firstWord.Length; i++)
                    {
                        total += (int)firstWord[i];
                    }
                }
                else
                {
                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        total += (int)secondWord[i];
                    }
                    n = firstWord.Length;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int firstNum = (int)firstWord[i];
                int secondNum = (int)secondWord[i];

                total += firstNum * secondNum;
            }

            Console.WriteLine(total);
        }
    }
}
