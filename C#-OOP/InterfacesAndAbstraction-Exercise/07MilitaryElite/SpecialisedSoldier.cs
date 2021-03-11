using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps { get; private set; }
    }
}
