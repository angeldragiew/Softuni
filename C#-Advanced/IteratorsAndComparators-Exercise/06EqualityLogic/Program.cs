using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person(name, age);

                peopleSet.Add(person);
                peopleSortedSet.Add(person);
            }
            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleSet.Count);
        }
    }
}
