using System;

namespace Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            NotAKitchen kitchen = new NotAKitchen();

            Chef chef = new Chef(kitchen);
            chef.Kitchen.Cook();

            Waiter waiter = new Waiter(kitchen);
            waiter.Kitchen.Order();

            Technician technician = new Technician(kitchen);
            technician.Kitchen.Repair();
        }
    }
}
