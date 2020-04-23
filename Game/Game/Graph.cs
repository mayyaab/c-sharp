using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Graph
    {
        private const int Height = 6;
        private const int Width = 6;


        public Graph()
        {
        }

        public static void RandomizeArray()
        {
            int[,] array = new int[Height, Width];
            Random random = new Random();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    array[i, j] = random.Next(4);

                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

