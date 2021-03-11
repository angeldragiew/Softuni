using System;
using System.Collections.Generic;

namespace _09ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);
                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);
            }

            foreach (var citizen in citizens)
            {
                IPerson person = citizen;
                IResident residet = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(residet.GetName());
            }
        }
    }
}
