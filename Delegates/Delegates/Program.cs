using System;

namespace Delegates
{
    class Program
    {
        public delegate double PerformCalculation(double x, double y);

        public static double Addition(double a, double b)
        {
            Console.WriteLine("a + b is "+ (a+b));
            return a + b;
        }
        public static double Devision(double a, double b)
        {
            Console.WriteLine("a / b is " + (a / b));
            return a / b;
        }
        public static double Substraction(double a, double b)
        {
            Console.WriteLine("a - b is " + (a - b));
            return a - b;
        }

        static void Main(string[] args)
        {
            PerformCalculation getSum = Addition;
            //getSum(5.0, 5.0);
            PerformCalculation getQuotient = Devision;
            //getQuotient(5.0, 5.0);

            PerformCalculation multiCalc = getSum + getQuotient;
            multiCalc += Substraction;
            multiCalc(3.2, 3.2);


        }

    }
}
