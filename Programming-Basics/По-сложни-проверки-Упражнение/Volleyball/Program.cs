using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInHomeTown = int.Parse(Console.ReadLine());
            int weekendsInSofia = 48 - weekendsInHomeTown;

            double gameInHolidays = holidays * 2.0 / 3.0;
            double gameInSofia = weekendsInSofia * 3.0 / 4.0;
            double gameInHomeTowns = weekendsInHomeTown;

            double totalGames = gameInHolidays + gameInSofia + gameInHomeTowns;
            if(year == "leap")
            {
                totalGames *= 1.15;
                Console.WriteLine(Math.Floor(totalGames));
            }
            else
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }
    }
}
