using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> setOfPrivates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> privates)
            :base(id, firstName, lastName, salary)
        {
            this.setOfPrivates = privates;
        }
        public IReadOnlyCollection<Private> SetOfPrivates => this.setOfPrivates.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastsName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var currPrivate in SetOfPrivates)
            {
                sb.AppendLine($"    {currPrivate.ToString()}");
            }
            return sb.ToString().Trim();
        }

    }
}
