using System;

namespace jaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare jaggedArray
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] { 2, 3, 4, 5, 11 };
            jaggedArray[1] = new int[] { 1, 2, 4 };
            jaggedArray[2] = new int[] { 2, 3 };

            //alternative way
            // [array1([12],[23],[3])],[array2([42],[23])],[array3([2],[3],[3])]
            int[][] jaggedArray2 = new int[][]
            {
                new int[] { 2, 3, 4, 5, 11 },
                new int[] { 1, 2, 4 },
                new int[] { 2, 3 }
            };

            Console.WriteLine("The value in the middle of the first entry is {0}", jaggedArray2[0][2]);

            for (int i = 0; i<jaggedArray2.Length; i++)
            {
                Console.WriteLine("Element at position {0} ", i);
                for (int j = 0; j< jaggedArray2[i].Length; j++)
                {
                    Console.WriteLine("{0} ", jaggedArray2[i][j]);
                }
            }
            Console.ReadKey();
        }
    }
}
