using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    //this class is a blue print of a datatype
    class Human
    {

        //member variable
        public string firstName;
        public string lastName;

        //member
        public void IntroduceMySelf()
        {
            Console.WriteLine("My name is {0}", firstName +" "+ lastName) ;
        }


    }
}
