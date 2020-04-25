using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game
{
    // Done Rename to Field
    public class Field
    {
        int height = 6;
        int width = 6;

        int[,] array = new int[6,6];
        //Done Have a array as a member variable
        //Done Make constructor accepting height & width

        public Field()
        {
        }

        public Field(int height, int width)
        {
            height = this.height;
            width = this.width;
            //array[this.height, this.width];
        }

        // Add function PlaceBalls that will place 3 balls on a field at random positions
        // PlaceBalls()
        public void PlaceBalls()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                var heightElement = random.Next(height);
                var widthElement = random.Next(width);

                if (array[heightElement, widthElement] == 0)
                {
                    array[heightElement, widthElement] = random.Next(1, 4);
                }
                else
                {
                    continue;
                }
            }
            Print();
        }


        // Modify to a function "Print" which prints the field
        public void RandomizeArray()
        {
            Random random = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = random.Next(4);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}

