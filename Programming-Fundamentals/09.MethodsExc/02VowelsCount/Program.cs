using System;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int vowels = CountVowels(word);

            Console.WriteLine(vowels);
        }

        static int CountVowels(string word)
        {
            char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                for (int z = 0; z < vowels.Length; z++)
                {
                    if(word[i] == vowels[z])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
