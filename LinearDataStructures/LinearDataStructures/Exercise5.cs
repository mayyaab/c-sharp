using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinearDataStructures
{
    class Exercise5
    {
        /*   Write a program, which removes all negative numbers from a sequence.*/
        public static void Ex5()
        {
            List<int> ex5List = new List<int>();
            ex5List.Add(19);
            ex5List.Add(-10);
            ex5List.Add(12);
            ex5List.Add(-6);
            ex5List.Add(-3);
            ex5List.Add(34);
            ex5List.Add(-2);
            ex5List.Add(5);

            List<int> positiveList = RemoveNegativeElements(ex5List);

            foreach (int i in positiveList)
            {
                Console.WriteLine(i);
            }
        }

        private static List<int> RemoveNegativeElements(List<int> ex5List)
        {
            List<int> positiveList = new List<int>();
            for (int i = 0; i < ex5List.Count; i++)
            {
                if (ex5List[i] > 0)
                {
                    int toAdd = ex5List[i];
                    positiveList.Add(toAdd);
                }
            }

            return positiveList;
        }
    }
}
