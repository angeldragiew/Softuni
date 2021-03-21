using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Manager risto", new List<string>() { "1dokument", "2dokument" });
            Employee employee = new Employee("Prosto employee");


            DetailsPrinter detailsPrinter = new DetailsPrinter(new List<IEmployee>() { manager,employee});
            detailsPrinter.PrintDetails();
        }
    }
}
