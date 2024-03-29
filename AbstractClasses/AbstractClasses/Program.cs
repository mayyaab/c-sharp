﻿using System;
using System.Reflection.Metadata;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = {new Sphere(4), new Cube(3)};

            foreach (Shape shape in shapes)
            {
                shape.GetInfo();
                Console.WriteLine("{0} has a volume of {1}", shape.Name, shape.Volume());
            }
        }
    }
}
