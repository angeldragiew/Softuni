﻿using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;

        private readonly List<IDriver> drivers;
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public int Laps
        {
            get { return laps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers.ToList();

        public void AddDriver(IDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            drivers.Add(driver);
        }
    }
}
