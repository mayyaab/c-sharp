using System;
using System.Collections.Generic;

namespace PolymorphismC
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Audi(200, "blue", "A4"),
                new BMW(250, "red", "M3")
            };

            foreach (var car in cars)
            {
                car.Repair();
            }

            Car bmwz3 = new BMW(200, "black", "Z3");
            Car audiA3 = new Audi(100, "green", "A3");

            bmwz3.ShowDetails();
            audiA3.ShowDetails();

            BMW bmwM5 = new BMW(330, "white", "M5");
            bmwM5.ShowDetails();

            Car carB = (Car) bmwM5;
            carB.ShowDetails();
        }
    }
}
