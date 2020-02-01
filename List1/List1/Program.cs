using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {

        static void Main(string[] args)
        {

            DoublyLinkedList doubly = new DoublyLinkedList();
            doubly.AddElement(13);
            doubly.AddElement(14);
            doubly.AddElement(15);
            doubly.AddElement(16);
            doubly.AddElement(17);
            doubly.PrintList();
            Console.WriteLine("-----------");
            var a = doubly.GetNodeByIndex(2);
            doubly.DeleteNElement(a);
            Console.WriteLine("-----------");
            doubly.PrintList();
            Console.ReadKey();

        }
    }
}
