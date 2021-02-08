using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars = new List<Car>();
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new List<Car>(capacity);
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public int Count
        {
            get { return Cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                Cars = Cars.Where(c => c.RegistrationNumber != registrationNumber).ToList();
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                if (Cars.Any(c => c.RegistrationNumber == registrationNumber))
                {
                    Cars = Cars.Where((c => c.RegistrationNumber != registrationNumber)).ToList();
                }
            }
        }
    }
}
