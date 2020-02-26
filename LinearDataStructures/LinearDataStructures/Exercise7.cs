using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearDataStructures
{
    /*Write a program that finds in a given array of integers 
     (in the range [0…1000]) how many times each of them occurs.*/
    class Exercise7                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    {
        public static void Ex7()                                                              

        {        
            int[] array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Array.Sort(array);

            Array.ForEach(array, Console.WriteLine);

            int elementToCaompare = array[0];
            int countUnic = 0;

            for (int i = 0; i < array.Length; i++)
            { 
                
                if (array[i] == elementToCaompare)
                {
                    countUnic++;

                }
                else
                {
                    Console.WriteLine("{0} element -> {1} times", elementToCaompare, countUnic);
                    elementToCaompare = array[i];
                    countUnic = 1;
                }
            }
            Console.WriteLine("{0} element -> {1} times", elementToCaompare, countUnic);
        }
    }
}
