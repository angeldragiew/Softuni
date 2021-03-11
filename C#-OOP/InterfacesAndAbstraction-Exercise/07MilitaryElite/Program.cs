using System;
using System.Collections.Generic;
using System.Linq;

namespace _07MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();            

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();

                string soldierType = data[0];

                if (soldierType == "Private")
                {
                    int id = int.Parse(data[1]);
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    Private currPrivate = new Private(id, firstName, lastName, salary);
                    soldiers.Add(currPrivate);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    int id = int.Parse(data[1]);
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    List<Private> setOfPrivates = new List<Private>();
                    for (int i = 5; i < data.Length; i++)
                    {
                        int privateId = int.Parse(data[i]);
                        Private currPrivate = (Private)soldiers.First(p => p.Id == privateId);
                        setOfPrivates.Add(currPrivate);
                    }
                    LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary, setOfPrivates);
                    soldiers.Add(lieutenant);
                }
                else if (soldierType == "Engineer")
                {
                    int id = int.Parse(data[1]);
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    string coprs = data[5];
                    if (coprs != "Airforces" && coprs != "Marines")
                    {
                        continue;
                    }

                    List<Repair> repairs = new List<Repair>();
                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string partName = data[i];
                        int hoursWorked = int.Parse(data[i + 1]);
                        Repair currRepair = new Repair(partName, hoursWorked);
                        repairs.Add(currRepair);
                    }
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, coprs, repairs);
                    soldiers.Add(engineer);
                }
                else if (soldierType == "Commando")
                {
                    int id = int.Parse(data[1]);
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    string coprs = data[5];

                    List<Mission> missions = new List<Mission>();
                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string codeName = data[i];
                        string state = data[i + 1];
                        if(state != "inProgress" && state!= "Finished")
                        {
                            continue;
                        }
                        Mission mission = new Mission(codeName, state);
                        missions.Add(mission);
                    }
                    Commando commando = new Commando(id, firstName, lastName, salary, coprs, missions);
                    soldiers.Add(commando);
                }
                else if (soldierType == "Spy")
                {
                    //"Spy <id> <firstName> <lastName> <codeNumber>"
                    int id = int.Parse(data[1]);
                    string firstName = data[2];
                    string lastName = data[3];
                    int codeNumber = int.Parse(data[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
