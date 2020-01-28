using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {
        static void foo(out Node n, out Node m)
        {
            n = new Node() { data = 10 };
            m = new Node() { data = 11 };
        }

        static void Main(string[] args)
        {
            Node kk; // = new Node() { data = 3 };
            Node mm;

            foo(out kk, out mm);
            Console.WriteLine(kk.data);
            Console.WriteLine(mm.data);

            List myList1 = new List();
            myList1.AddElement(9);
            myList1.AddElement(10);
            myList1.AddElement(8);
            myList1.AddElement(1000);
            myList1.AddElement(200);
            myList1.AddElement(55);
            myList1.PrintList();
            Console.WriteLine("______");

            //Console.WriteLine(myList1.MaxElement(2)); 
            //Console.WriteLine(myList1.IncreasingOrDecrising()); 
            // Console.WriteLine(myList1.IsPresentedInTheList(3, null));
            // myList1.UniqElementsInTheList().PrintList();
            //Console.WriteLine(myList1.DistinctElementsInTheListV3());
            //Console.WriteLine(myList1.MaxElement());
            //Console.WriteLine(myList1.MinElement());
            //Console.WriteLine(myList1.MinElementPreviousReturnNode().data);
            myList1.SortListNodes();

            myList1.PrintList();
            Console.ReadLine();
        }
    }
}
