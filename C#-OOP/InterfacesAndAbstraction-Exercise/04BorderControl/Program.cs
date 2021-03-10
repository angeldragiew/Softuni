using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> allGuests = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) !="End")
            {
                string[] data = input.Split();

                if (data.Length > 2)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    IIdentifiable human = new Citizen(name, age, id);
                    allGuests.Add(human);
                }
                else
                {
                    string model = data[0];
                    string id = data[1];
                    IIdentifiable robot = new Robot(model, id);
                    allGuests.Add(robot);
                }
            }

            string endsWith = Console.ReadLine();
            List<string> detainedIds = allGuests.Where(g => g.Id.EndsWith(endsWith)).Select(g=>g.Id).ToList();
            foreach (var id in detainedIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
