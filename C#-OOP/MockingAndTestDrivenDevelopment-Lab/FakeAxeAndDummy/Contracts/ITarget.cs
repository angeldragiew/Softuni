using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Contracts
{
    public interface ITarget
    {
        bool IsDead();

        int GiveExperience();

        void TakeAttack(int attackPoints);
    }
}
