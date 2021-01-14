using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] studentAttributes = Console.ReadLine().Split(" ").ToArray();
                string fName = studentAttributes[0];
                string lName = studentAttributes[1];
                double grade = double.Parse(studentAttributes[2]);

                Student student = new Student(fName, lName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(a => a.Grade).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, students));
        }

        class Student
        {
            public Student(string fName, string lName, double grade)
            {
                FirstName = fName;
                LastName = lName;
                Grade = grade;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }
        }
    }
}
