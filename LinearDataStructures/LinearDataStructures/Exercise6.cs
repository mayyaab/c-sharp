using System;
using System.Collections;
using System.Collections.Generic;


namespace LinearDataStructures
{
    /* Write a program that removes from a given sequence all numbers that appear an odd count of times.*/
    class Exercise6
    {
        public static void Ex6()
        {

            List<int> ex6List = new List<int>();
            ex6List.Add(4);
            ex6List.Add(2);
            ex6List.Add(2);
            ex6List.Add(5);
            ex6List.Add(2);
            ex6List.Add(3);
            ex6List.Add(2);
            ex6List.Add(3);
            ex6List.Add(1);
            ex6List.Add(5);
            ex6List.Add(2);

            Dictionary<int, int> hashTable = new Dictionary<int, int>();

            for (int i = 0; i < ex6List.Count; i++)
            {
                if (!hashTable.ContainsKey(ex6List[i]))
                {
                    hashTable.Add(ex6List[i],  1) ;
                }
                else
                {
                    hashTable[ex6List[i]] = hashTable[ex6List[i]] + 1;
                }
            }

            foreach (var elementsDictionary in hashTable)
            {
                Console.WriteLine("{0} element -> {1} times", elementsDictionary.Key, elementsDictionary.Value);
            }

            foreach (var entry in hashTable)
            {
                if (entry.Value % 2 == 1)
                {
                    for (int index = ex6List.Count-1; index >= 0; index--)
                    {
                        if (ex6List[index] == entry.Key)
                        {
                            ex6List.RemoveAt(index);
                        }
                    }
                }
                
            }
            foreach (int i in ex6List)
            {
                Console.WriteLine(i);
            }
        }
    }
}
