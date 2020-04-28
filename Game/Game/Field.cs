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

        // TG: think about strategies to make the function more effective.
        public void PlaceBalls()
        {
            var random = new Random();
            // TG: extract 3 to a separate variable or constant.
            for (int i = 0; i < 3;)
            {
                var heightElement = random.Next(height);
                var widthElement = random.Next(width);
                if (array[heightElement, widthElement] == 0)
                {
                    // TG: extract number of color to a separate constant.
                    array[heightElement, widthElement] = random.Next(1, 4);
                    i++;
                }
            }
            Print();
        }

        // TG: implement the function
        void MoveBall(/*Position source, Position destination */)
        {

        }

        public void Print()
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Console.Write("{0,4}", array[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

