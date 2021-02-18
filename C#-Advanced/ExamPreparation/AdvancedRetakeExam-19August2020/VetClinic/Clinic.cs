﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count
        {
            get { return data.Count; }
        }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = data.FirstOrDefault(p => p.Name == name);
            if (petToRemove == null)
            {
                return false;
            }

            data.Remove(petToRemove);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderByDescending(p => p.Age).First();
            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
