using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;
        public Druid(string name)
            : base(name, druidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}
