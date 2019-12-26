using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    //this class is a blue print of a datatype
    class Human
    {

        //member variable
        private string firstName;
        private string lastName;
        private string eyeColor;
        private int age;
        //default constructor
        public Human()
        {
            Console.WriteLine("Human is created");
        }

        public Human(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        //paramiritirized constructor
        public Human(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        //member
        public void IntroduceMySelf()
        {
            if (age != 0)
            {
                Console.WriteLine("My name is {0} {1} and my color of hairs is {2} and years {3} old", firstName, lastName, eyeColor, age);
            }
            else
            {
                Console.WriteLine("My name is {0} {1} and my color of hairs is {2} ", firstName, lastName, eyeColor);
            }
        }


    }
}
