using System;

namespace InheritanceChallenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Maya = new Employee("MayyaA", "Maya", 2000);
            Boss Tigran = new Boss("TigranG", "Tigran", 20000, "Audi");
            Trainees MayaA = new Trainees("Mayahka", "Maya", 500, 20, 10);

            Maya.Work();
            Maya.Pause();

            Tigran.Laed();

            MayaA.Learn();
            MayaA.Work();

            Console.ReadKey();
        }
    }
}
