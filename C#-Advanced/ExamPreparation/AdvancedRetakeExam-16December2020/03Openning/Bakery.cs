using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            data = new List<Employee>(capacity);
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return data.Count; }
        }
        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employeeToRemove = data.FirstOrDefault(e => e.Name == name);
            if (employeeToRemove == null)
            {
                return false;
            }
            data.Remove(employeeToRemove);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldest = data.OrderByDescending(e => e.Age).First();//todo:
            return oldest;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var empl in data)
            {
                sb.AppendLine(empl.ToString());
            }
            return sb.ToString();
        }
    }
}
