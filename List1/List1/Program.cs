using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {
        static void Main(string[] args)
        {
            List myList1 = new List();
            myList1.AddElement(-1);
            myList1.AddElement(8);
            myList1.AddElement(3);
            myList1.AddElement(-122);
            myList1.PrintList();
            Console.WriteLine("______");
            Console.WriteLine(myList1.ReturnTheMinValueInTheList()); 
            Console.ReadLine();
        }
    }
}
