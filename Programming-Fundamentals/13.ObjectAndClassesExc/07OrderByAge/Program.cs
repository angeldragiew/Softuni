using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] attributes = input.Split().ToArray();
                string name = attributes[0];
                string id = attributes[1];
                int age = int.Parse(attributes[2]);

                Person person = new Person(name, id, age);
                people.Add(person);
            }

            people = people.OrderBy(a => a.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, people));

        }

        class Person
        {
            public Person(string name, string id, int age)
            {
                Name = name;
                ID = id;
                Age = age;
            }
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
    }
}
