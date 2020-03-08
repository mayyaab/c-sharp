using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceChallenge2
{
    class Boss: Employee
    {
        protected string companyCar { get; set; }

        public Boss(string name, string firstName, int salary, string companyCar): base(name, firstName, salary)
        {
            this.name = firstName;

        }

        public void Laed()
        {
            Console.WriteLine("Lead");
        }
    }
}
