using System;
using System.Collections.Generic;

namespace List1
{
    class Program
    {

        static void Main(string[] args)
        {

            DoublyLinkedList doubly = new DoublyLinkedList();
            doubly.AddElement(14);
            doubly.AddElement(15);
            doubly.AddElement(16);
            doubly.PrintList();
            Console.WriteLine("-----------");
            doubly.DeleteNElement(null);
            Console.WriteLine("-----------");
            doubly.PrintList();

        }
    }
}
