using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastsName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().Trim();
        }
    }
}
