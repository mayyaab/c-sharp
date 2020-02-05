using System;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    class Exercise2
    {
        public static void Ex2()
        {
            /* Write a program, which reads from the console N integers and 
               prints them in reversed order. Use the Stack<int> class. */
            Stack<int> stack = new Stack<int>();

            Console.WriteLine("Enter the number of integer for the stack: ");
            string userInput = Console.ReadLine();
            int nIntegers = int.Parse(userInput);

            Console.WriteLine("Enter {0} integers for the stack", nIntegers);
            while (stack.Count < nIntegers)
            {
                string userInputForStack = Console.ReadLine();
                try
                {
                    int elementToAdd = int.Parse(userInputForStack);
                    stack.Push(elementToAdd);
                }
                catch
                {
                    Console.WriteLine("Invalid formt, write again");
                }
            }
            Console.WriteLine("Your input in reversed order");
            while (stack.Count > 0)
            {
                int stackData = stack.Pop();
                Console.WriteLine(stackData);
            }
        }

    }
}
