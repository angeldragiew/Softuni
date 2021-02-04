using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person Angel = new Person();
            Angel.Name = "Angel";
            Angel.Age = 94;

            Person Ivan = new Person() { Name = "Ivan", Age = 99 };
            
        }
    }
}
