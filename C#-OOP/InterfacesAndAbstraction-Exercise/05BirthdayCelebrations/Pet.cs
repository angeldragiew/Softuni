using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IPet
    {
        public Pet(string name, string date)
        {
            Name = name;
            BirthDate = date;
        }
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
