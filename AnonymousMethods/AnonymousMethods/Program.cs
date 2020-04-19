using System;

namespace AnonymousMethods
{
    class Program
    {
        public delegate string GetTextDelegate(string name);

        public delegate double GetResultDelegate(double a, double b);
        static void Main(string[] args)
        {
            GetTextDelegate getTextDelegate = delegate(string name) { return "Hello, " + name; };
            //expression lambda
            GetTextDelegate getHelloText = (string name) => { return "Hello, " + name; };

            //statement lambda
            GetTextDelegate getGoodbyeText = (string name) =>
            {
                Console.WriteLine("I'm inside of an statement lambda");
                return "Goodbye, " + name;
            };

            GetTextDelegate getWelcomeText = name => "Welcome, " + name;

            GetResultDelegate getSum = (a, b) => a + b;

            GetResultDelegate getProduct = (a, b) => a * b;

            Console.WriteLine(getWelcomeText("Mayya"));
            Display(getTextDelegate);
            DisplayNum(getSum);
            DisplayNum(getProduct);
        }

        static void DisplayNum(GetResultDelegate getResultDelegate)
        {
            Console.WriteLine(getResultDelegate(3.5, 2.6));
        }

        static void Display(GetTextDelegate getTextDelegate)
        {
            Console.WriteLine(getTextDelegate("World"));
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
