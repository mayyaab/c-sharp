using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismC
{
    class Car
    {
        public int HP { get; set; }
        public string Color { get; set; }

        //has a relationship
        protected CarIDInfo carIdInfo = new CarIDInfo();

        public void SetCarIDInfo(int idNum, string owner)
        {
            carIdInfo.IDNum = idNum;
            carIdInfo.Owner = owner;
        }

        public void GetCarIDInfo()
        {
            Console.WriteLine("The car has the ID {0} and is owned by {1}", carIdInfo.IDNum, carIdInfo.Owner);
        }

        //default constartractor
        public Car()
        {

        }

        public Car(int hp, string color)
        {
            this.HP = hp;
            this.Color = color;
        }

        public void ShowDetails()
        {
            Console.WriteLine("HP: " + HP + " color: " + Color);
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired");
        }
    }
}
