using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Person : IPerson
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
