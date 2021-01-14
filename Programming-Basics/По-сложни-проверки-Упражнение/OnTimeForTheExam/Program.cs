using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHours = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());
            int hours = 0;
            int minutes = 0;

            examMinutes += examHours * 60;
            arrivalMinutes += arrivalHours * 60;
            int difference = 0;
            if (arrivalMinutes > examMinutes)
            {
                difference = arrivalMinutes - examMinutes;
                Console.WriteLine("Late");
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hours = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
                }
            }else if(arrivalMinutes== examMinutes)
            {
                Console.WriteLine("On time");
            }
            else
            {
                difference = examMinutes-arrivalMinutes;
                if (difference < 60)
                {
                    if (difference <= 30)
                    {
                        Console.WriteLine("On time");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                    }
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    hours = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
                }
            }
        }
    }
}
