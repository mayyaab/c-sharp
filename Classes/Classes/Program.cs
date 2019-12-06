using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an object of my class
            //an unstance of human
            Human mayya = new Human("Mayya", "Abzhigitova", "browne", 24);
            Human tigran = new Human("Tigram", "Jan", "browne", 100);
            Human mia = new Human("Mia", "Kim", "blue", 1);
            //access public variables from outside and even change it
            //mayya.firstName = "Mayya";
            //mayya.lastName = "Abzhigitova";
            //call method of a class
            mayya.IntroduceMySelf();
            tigran.IntroduceMySelf();
            mia.IntroduceMySelf();



            
            Console.ReadKey();
        }
    }
}
