using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using Algorithms_DataStruct_Lib;

namespace Algorithms_CSharp_Course
{
    class Program
    {   
        static void Main(string[] args)
        {
            //300 milisecons for 1k
            //14 second for 4k
            //1 min 36 sec for 8k 
            /*var ints = In.ReadInts("4Kints.txt").ToArray();

            var watch = new Stopwatch();
            watch.Start();

            var triplets = ThreeSum.Count(ints);

            watch.Stop();

            Console.WriteLine($"The number of \"zero-sum\" triplets: {triplets}");
            Console.WriteLine($"Time taken: {watch.Elapsed:g}");

            Console.Read();*/

            //Algorithms_DataStruct_Lib.Sorting.SelectionSort(int[4], 12, 14, 24, 16) ;

            var bstTest = new Bst<int>();
            bstTest.Insert(37);
            bstTest.Insert(28);
            bstTest.Insert(17);
            bstTest.Insert(24);
            bstTest.Insert(31);
            bstTest.Insert(29);
            bstTest.Insert(15);
            bstTest.Insert(20);
            bstTest.Insert(12);
            bstTest.Insert(38);

            foreach (var i in bstTest.TraverseInOrder())
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine();
            Console.WriteLine(bstTest.Min());
            Console.WriteLine(bstTest.Max());
            Console.WriteLine(bstTest.Get(20));
            Console.Read();
        }
    }
}
