using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceChallenge2
{
    class Employee
    {
        protected string name { get; set; }
        protected string firstName { get; set; }
        protected int salary { get; set; }

        public Employee()
        {
            name = "default";
            firstName = "default";
            salary = 1000;
        }

        public Employee(string name, string firstName, int salary)
        {
            this.name = name;
            this.firstName = firstName;
            this.salary = salary;
        }

        public void Work()
        {
            Console.WriteLine("Work");
        }

        public void Pause()
        {
            Console.WriteLine("Pause");
        }
    }
}
