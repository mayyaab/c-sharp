using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    // Rename to Field
    public class Graph
    {
        private const int Height = 6;
        private const int Width = 6;

        // Have a array as a member variable

        // Make constructor accepting Height & Width
        public Graph()
        {
        }

        // Add function PlaceBalls that will place 3 balls on a field at random positions
        // PlaceBalls()

        // Modify to a function "Print" which prints the field
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

