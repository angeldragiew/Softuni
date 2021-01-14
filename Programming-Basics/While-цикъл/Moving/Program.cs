using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            int volume = width * heigth * length;
            bool enoughSpace = true;
            int cardboardVolume = 0;
            int cardboard = 0;
            string input = Console.ReadLine();

            while (input !="Done")
            {
                try
                {
                     cardboard = int.Parse(input);
                }
                catch
                {

                }
                
                cardboardVolume += cardboard;
                if (cardboardVolume >= volume)
                {
                    enoughSpace = false;
                    break;
                }
                input = Console.ReadLine();
            }

            if (enoughSpace)
            {
                Console.WriteLine($"{volume- cardboardVolume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {cardboardVolume - volume} Cubic meters more.");
            }
        }
    }
}
