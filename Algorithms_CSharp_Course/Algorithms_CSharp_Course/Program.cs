using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            var ints = In.ReadInts("4Kints.txt").ToArray();

            var watch = new Stopwatch();
            watch.Start();

            var triplets = ThreeSum.Count(ints);

            watch.Stop();

            Console.WriteLine($"The number of \"zero-sum\" triplets: {triplets}");
            Console.WriteLine($"Time taken: {watch.Elapsed:g}");

            Console.Read();
        }
    }
}
