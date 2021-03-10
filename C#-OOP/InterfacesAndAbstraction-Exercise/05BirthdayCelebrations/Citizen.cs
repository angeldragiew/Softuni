using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age, string id, string date)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = date;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }
        public string BirthDate { get; private set; }
       
    }
}
