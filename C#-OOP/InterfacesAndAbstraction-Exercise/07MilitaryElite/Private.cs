using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastsName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
