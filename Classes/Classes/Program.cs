using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an object of my class
            //an unstance of human
            Human mayya = new Human();
            //access public variables from outside and even change it
            mayya.firstName = "Mayya";
            mayya.lastName = "Abzhigitova";
            //call method of a class
            mayya.IntroduceMySelf();

            
            Console.ReadKey();
        }
    }
}
