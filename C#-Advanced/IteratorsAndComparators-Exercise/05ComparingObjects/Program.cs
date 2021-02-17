using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personInfo = input.Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person currPerson = new Person(name, age, town);
                people.Add(currPerson);
            }

            int personToCompareIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[personToCompareIndex];

            int countOfMatches = 1;
            int numberOfNotEqual = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (i == personToCompareIndex)
                {
                    continue;
                }

                Person person = people[i];
                if (personToCompare.CompareTo(person) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    numberOfNotEqual++;
                }
            }

            if (countOfMatches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {numberOfNotEqual} {people.Count}");
            }
        }


    }
}
