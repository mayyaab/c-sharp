using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {
        static void Main(string[] args)
        {
            List myList1 = new List();
            myList1.AddElement(9);
            myList1.AddElement(9);
            myList1.AddElement(5);
            myList1.AddElement(2);
            myList1.AddElement(1);
            myList1.PrintList();
            Console.WriteLine("______");
            Console.WriteLine(myList1.IncreasingOrDecrising()); 
            Console.ReadLine();
        }
    }
}
