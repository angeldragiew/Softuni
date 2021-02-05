﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }
        public List<Person> Members { get; set; }

        public void AddMember(Person person)
        {
            Members.Add(person);
        }

        public Person GetOldestGetOldestMember()
        {
            return this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
