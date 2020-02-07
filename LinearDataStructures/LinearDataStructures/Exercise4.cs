using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinearDataStructures
{
    class Exercise4
    {
        /*Write a method that finds the longest subsequence of equal numbers
          in a given List<int> and returns the result as new List<int>. 
          Write a program to test whether the method works correctly.*/
        public static void Ex4()
        {
            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(2);
            intList.Add(1);
            intList.Add(2);
            intList.Add(2);
            intList.Add(2);
            intList.Add(2);
            intList.Add(1);
            intList.Add(1);
            intList.Add(1);
            intList.Add(1);
            int start = 0;
            int newStart = 0;
            int length = 1;
            int maxLength = 1; 
            for (int i = intList.Count-1; i >= 0; i--)
            {
                
                if (start == intList.ElementAt(i))
                {
                    length++;
                }
                else
                {
                    if (maxLength < length)
                    {
                        maxLength = length;
                        newStart = start;
                    }
                    length = 1;
                }
                start = intList.ElementAt(i);
            }
            List<int> listToPrint = new List<int>();
            for (int i = 1; i< maxLength+1; i++)
            {
                listToPrint.Add(newStart);
            }
            Console.WriteLine("First list");
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("New list");

            foreach (int i in listToPrint)
            {
                Console.WriteLine(i);
            }

        }
    }
}
