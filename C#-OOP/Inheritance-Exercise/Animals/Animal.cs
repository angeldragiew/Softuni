using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            if (age < 0)
            {
                throw new InvalidOperationException("Invalid input!");
            }
            else
            {
                this.age = age;
            }
            Gender = gender;
        }
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid input!");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Gender { get; set; }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
