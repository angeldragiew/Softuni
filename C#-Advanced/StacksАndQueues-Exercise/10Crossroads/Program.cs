using System;
using System.Collections.Generic;

namespace _10Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> jam = new Queue<string>();

            int carPassed = 0;
            bool success = true;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {

                if (command == "green")
                {
                    int greenLight = greenLightDuration;
                    int freeWindow = freeWindowDuration;
                    int carsInJam = jam.Count;

                    for (int i = 0; i < carsInJam; i++)
                    {
                        if (jam.Count > 0 && greenLight - jam.Peek().Length > 0)
                        {
                            greenLight -= jam.Dequeue().Length;
                            carPassed++;
                        }
                        else if (jam.Count > 0 && greenLight - jam.Peek().Length <= 0)
                        {
                            string car = jam.Dequeue();
                            int timeLeft = greenLight + freeWindow;

                            if (timeLeft - car.Length < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[Math.Abs(timeLeft)]}.");
                                success = false;
                                goto End;
                            }
                            carPassed++;
                            break;


                        }
                    }
                }
                else
                {
                    jam.Enqueue(command);
                }


            }

            End:
            if (success)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassed} total cars passed the crossroads.");
            }
        }
    }
}
