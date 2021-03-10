using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string type = data[0];

                if (type == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string date = data[4];
                    IBirthable birthable = new Citizen(name, age, id, date);
                    birthables.Add(birthable);
                }
                else if (type == "Pet")
                {
                    string name = data[1];
                    string date = data[2];
                    IBirthable birthable = new Pet(name,date);
                    birthables.Add(birthable);

                }
            }

            int year = int.Parse(Console.ReadLine());
            List<string> birthDates = birthables.Where(b => b.BirthDate.EndsWith($"/{year}")).Select(b => b.BirthDate).ToList();

            foreach (var date in birthDates)
            {
                Console.WriteLine(date);
            }
        }
    }
}
