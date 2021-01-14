using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            char office = 'O';
            char apartment = 'A';
            char largeApartment = 'L';

            char room = 's';

            for (int f = floors; f >= 1; f--)
            {
                if (f == floors)
                {
                    room = largeApartment;
                }
                else if (f % 2 == 0)
                {
                    room = office;
                }
                else if (f % 2 != 0)
                {
                    room = apartment;
                }

                for (int r = 0; r < rooms; r++)
                {
                    if(r == rooms-1)
                    {
                        Console.WriteLine($"{room}{f}{r}");
                    }
                    else
                    {
                        Console.Write($"{room}{f}{r} ");
                    }
                }
            }
        }
    }
}
