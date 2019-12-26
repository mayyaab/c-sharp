using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare 2D affay


            string[,] matrix;

            //3d
            string[,,] threeD;

            //two dementional array
            int[,] array2D = new int[,]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };
            Console.WriteLine("Central value is {0}", array2D[1,1]);
            Console.WriteLine("Row 3  {0}", array2D[2, 0]);

        }
    }
}
