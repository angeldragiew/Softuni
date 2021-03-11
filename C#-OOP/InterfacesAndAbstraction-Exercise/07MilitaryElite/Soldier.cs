using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastsName = lastName;
        }
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastsName { get; private set; }

        public abstract override string ToString();
    }
}
