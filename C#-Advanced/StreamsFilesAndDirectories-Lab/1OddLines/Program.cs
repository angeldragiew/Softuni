using System;
using System.IO;

namespace _1OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                int counter = 1;
                string line = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
