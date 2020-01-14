using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {
        static void Main(string[] args)
        {
            List myList1 = new List();
            //myList1.AddElement(1);
            //myList1.AddElement(3);
            myList1.AddElement(2);
            myList1.AddElement(1);
            myList1.PrintList();
            Console.WriteLine("______");
           // Console.WriteLine(myList1.IsSortedAscendingIfDeleteOneNode());

            List newList = new List();
            newList.AddElement(3);
            newList.AddElement(2);
            newList.AddElement(1);
            newList.PrintList();
            Console.WriteLine("______");
            Console.WriteLine(myList1.IsEqual2(newList)); 



            Console.ReadLine();
        }
    }
}
