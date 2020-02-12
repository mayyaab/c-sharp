using System;
using System.Collections.Generic;
using System.Text;


namespace LinearDataStructures
{
    /* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
     * Write a program that finds the majorant of given array and prints it. 
     * If it does not exist, print "The majorant does not exist!".*/

    class Exercise8
    {
        public static void Ex8()
        {
            int[] array = new int[] { 2, 2, 3, 1, 2, 3, 4, 3, 3 };

            Array.Sort(array);
            int element = array[0];
            int countElement = 0;

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] == element)
                {
                    countElement++;
                }

                else
                {
                    if (countElement >= array.Length / 2 + 1)
                    {
                        Console.WriteLine("The majorant element is {0} , count {1} times", element, countElement);
                        return;
                    }
                    else
                    {
                        element = array[i];
                        countElement = 1;
                    }

                }
            }


        }
    }
}
