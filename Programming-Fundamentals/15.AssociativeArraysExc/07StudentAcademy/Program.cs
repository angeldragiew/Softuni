using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double> students = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(student) == false)
                {
                    students.Add(student, grade);
                }
                else
                {
                    students[student] += grade;
                    students[student] /= 2;
                }
            }

            students = students.Where(x => x.Value >= 4.50).ToDictionary(x => x.Key, x => x.Value);
            students = students.OrderByDescending(x=>x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
