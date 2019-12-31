using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {
        static void Main(string[] args)
        {



            List myList1 = new List();
            myList1.AddElement(4);
            myList1.AddElement(3);
            myList1.AddElement(4);
            myList1.AddElement(0);

            myList1.PrintList();
            Console.WriteLine("______");
            myList1.DeleteElementByValue(0);
            myList1.PrintList();
            Console.ReadLine();








        }
    }
}
