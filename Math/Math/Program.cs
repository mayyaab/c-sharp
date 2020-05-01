using System;


namespace Math
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ceiling: " + System.Math.Ceiling(15.3));
            Console.WriteLine("Floor: " + System.Math.Floor(15.3));

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine("Lower of num1 {0} and num2 {1} is {2}", num1, num2, System.Math.Min(num1, num2));

            Console.WriteLine("3 to the power of 5 is {0}", System.Math.Pow(3,5));
            Console.WriteLine("PI is {0}", System.Math.PI);

            Console.WriteLine("The square root of 25 is {0}", System.Math.Sqrt(25));
            Console.WriteLine("Always positive is {0}", System.Math.Abs(-25));

            Console.ReadLine();
        }
    }
}
