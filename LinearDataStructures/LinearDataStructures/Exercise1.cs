﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinearDataStructures
{
    class Exercise1
    {
        /* Write a program that reads from the console a sequence of positive integer numbers.
           The sequence ends when empty line is entered.
           Calculate and print the sum and the average of the sequence.
           Keep the sequence in List<int>.*/

        public static void Ex1()
        {
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
                    Console.WriteLine("Invalid format, write again");
                }
            }

            int sum = intList.Sum();
            double average = intList.Average();


            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("The sum of list is {0}", sum);
            Console.WriteLine("The average of list is {0}", average);
        }
    }
}
