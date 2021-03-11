using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public class Commando : SpecialisedSoldier,ICommando
    {
        private List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions => this.missions.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastsName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
