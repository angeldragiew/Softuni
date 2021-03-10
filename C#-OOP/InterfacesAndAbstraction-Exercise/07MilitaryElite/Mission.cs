using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; private set; }

        public string State { get; private set; }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
