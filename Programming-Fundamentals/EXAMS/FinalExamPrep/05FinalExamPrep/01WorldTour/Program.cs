using System;

namespace _01WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = input.Split(":");

                string command = cmdArgs[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string givenString = cmdArgs[2];
                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, givenString);
                    }
                    Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int end = int.Parse(cmdArgs[2]);

                    if (start >= 0 && start < stops.Length && end >= 0 && end < stops.Length)
                    {
                        stops = stops.Remove(start, end - start + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (command == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    stops = stops.Replace(oldString, newString);
                    Console.WriteLine(stops);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
