using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person: IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            int nameHash = this.Name.GetHashCode();
            int ageHash = this.Age.GetHashCode();
            return nameHash + ageHash;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public int CompareTo( Person otherPerson)
        {
            if (Name.CompareTo(otherPerson.Name) != 0)
            {
                return Name.CompareTo(otherPerson.Name);
            }

            if (Age.CompareTo(otherPerson.Age) != 0)
            {
                return Age.CompareTo(otherPerson.Age);
            }

            return 0;
        }
    }
}
