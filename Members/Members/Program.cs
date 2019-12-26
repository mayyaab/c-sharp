using System;

namespace Members
{
    class Program
    {
        static void Main(string[] args)
        {
            Member mem1 = new Member();
            mem1.Introducing(true);
            mem1.Introducing(false);
            Console.ReadKey();
        }
    }
}
