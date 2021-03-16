using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;
        public Warrior(string name)
            : base(name, warriorPower)
        {
        }
        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
