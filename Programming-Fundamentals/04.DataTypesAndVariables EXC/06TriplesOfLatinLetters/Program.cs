using System;

namespace _06TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < 97+n; i++)
            {
                for (int y = 97; y < 97 + n; y++)
                {
                    for (int z = 97; z < 97 + n; z++)
                    {
                        char iCh = (char)i;
                        char yCh = (char)y;
                        char zCh = (char)z;
                        Console.WriteLine($"{iCh}{yCh}{zCh}");
                    }
                }
            }
        }
    }
}
