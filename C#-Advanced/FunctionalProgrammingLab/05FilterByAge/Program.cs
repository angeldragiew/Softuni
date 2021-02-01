using System;
using System.Collections.Generic;

namespace _05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                int age = int.Parse(studentInfo[1]);
                Student student = new Student(name, age);
                students.Add(student);
            }

            string givenCondition = Console.ReadLine();
            int givenAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Student, bool> condition = GetAgeCondition(givenCondition, givenAge);
            Action<Student> formatter = GetFormatter(format);

            PrintStudents(students, condition, formatter);
        }

        static void PrintStudents(List<Student> students, Func<Student, bool> condition, Action<Student> formatter)
        {
            foreach (var student in students)
            {
                if (condition(student))
                {
                    formatter(student);
                }
            }
        }

        static Action<Student> GetFormatter(string format)
        {
            switch (format)
            {
                case "name": return s => Console.WriteLine($"{s.Name}");
                case "age": return s => Console.WriteLine($"{s.Age}");
                case "name age": return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default: return null;
            }

        }
        static Func<Student, bool> GetAgeCondition(string givenCondition, int givenAge)
        {
            switch (givenCondition)
            {
                case "younger": return s => s.Age < givenAge;
                case "older": return s => s.Age >= givenAge;
                default: return null;
            }
        }

        class Student
        {
            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
