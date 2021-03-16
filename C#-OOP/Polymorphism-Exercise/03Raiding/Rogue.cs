using System;
using System.Collections.Generic;
using System.Text;

namespace _03Raiding
{
    public class Rogue : BaseHero
    {
        private const int roguePower = 80;
        public Rogue(string name)
            : base(name, roguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
