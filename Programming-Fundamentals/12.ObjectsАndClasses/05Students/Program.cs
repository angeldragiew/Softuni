using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] arr = input.Split().ToArray();

                Student student = new Student();
                student.FirstName = arr[0];
                student.LastName = arr[1];
                student.Age = int.Parse(arr[2]);
                student.Town = arr[3];
                IsStudentExisting(studentsList, arr[0], arr[1]);
                studentsList.Add(student);

            }

            string town = Console.ReadLine();


            List<Student> filteredStudents = studentsList.Where(s => s.Town == town).ToList();

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }


        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Town { get; set; }

        }

        static void IsStudentExisting(List<Student> studentList, string fName, string lName)
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].FirstName == fName && studentList[i].LastName == lName)
                {
                    studentList.Remove(studentList[i]);
                    break;
                }
            }
        }
    }
}
