using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : Person, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string date)
            :base(name, age)
        {
            Id = id;
            BirthDate = date;
        }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

        public override void BuyFood()
        {
            Food += 10;
        }
    }
}
