using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string animal = input;
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    if (animal == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                    }
                    else if (animal == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                    }
                    else if (animal == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                    }else if(animal== "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                    }else if (animal == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }
    }
}
