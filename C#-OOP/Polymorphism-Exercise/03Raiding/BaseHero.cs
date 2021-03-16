﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; private set; }
        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name}";
        }
    }
}
