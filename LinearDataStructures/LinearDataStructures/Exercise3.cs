using System;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    class Exercise3
    {
        public static void Ex3()
        {
            /*Write a program that reads from the console a sequence of positive 
              integer numbers. The sequence ends when an empty line is entered. 
              Print the sequence sorted in ascending order.*/

            List<int> intList = new List<int>();
            while (true)
            {
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    break;
                }

                try
                {
                    int elementToAdd = int.Parse(userInput);
                    if (elementToAdd < 0)
                    {
                        Console.WriteLine("Input should be positive");
                    }
                    else
                    {
                        intList.Add(elementToAdd);
                    }

                }
                catch
                {
                    Console.WriteLine("Invalid formt, write again");
                }
            }
            intList.Sort();
            Console.WriteLine("Sorted list");
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
