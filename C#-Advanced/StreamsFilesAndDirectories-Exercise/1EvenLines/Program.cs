using System;
using System.IO;
using System.Linq;

namespace _1EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        foreach (var currChar in charsToReplace)
                        {
                            line = line.Replace(currChar, '@');
                        }
                        string[] words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}
