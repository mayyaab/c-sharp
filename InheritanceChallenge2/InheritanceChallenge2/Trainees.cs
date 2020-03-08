using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceChallenge2
{
    class Trainees: Employee
    {
        protected int tigran; //field

        protected int workingHours { get; set; } //properties

        protected int schoolHours { get; set; }

        public Trainees(string name, string firstName, int salary, int workingHours, int schoolHours):base(name, firstName, salary)
        {
            this.workingHours = workingHours;
            this.schoolHours = schoolHours;
        }

        public void Learn()
        {
            Console.WriteLine("Learn");
        }

        public void  Work()
        {
            Console.WriteLine("Trainee work");
        }
    }
}
