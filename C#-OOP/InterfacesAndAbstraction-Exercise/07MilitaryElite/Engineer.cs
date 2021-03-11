using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps,List<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<Repair> Repairs=>this.repairs.AsReadOnly();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastsName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in Repairs)
            {
               sb.AppendLine($"    {repair.ToString()}");
            }
            return sb.ToString().Trim();
        }

        
    }
}
