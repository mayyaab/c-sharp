using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace Game
{
    public class Field
    {
        public int Height { get; }
        public int Width { get; }

        readonly int[,] _array;

        public Field() : this(9, 9)
        {
        }

        public Field(int height, int width)
        {
            Height = height;
            Width = width;

            _array = new int[height, width];
        }

        int GetColor( /*Position pos*/)
        {
            return 0;
        }

        // TG: think about strategies to make the function more effective.
        public void PlaceBalls()
        {
            var random = new Random();
            const int ballsCount = 3;

            // DONE TG: extract 3 to a separate variable or constant.
            for (int i = 0; i < ballsCount;)
            {
                var heightElement = random.Next(Height);
                var widthElement = random.Next(Width);
                if (_array[heightElement, widthElement] == 0)
                {
                    // TG: extract number of color to a separate constant.
                    _array[heightElement, widthElement] = random.Next(1, 4);
                    i++;
                }
            }
        }

        // TG: implement the function
        public void MoveBall(Position source, Position destination)
        {
            source = new Position(source._row, source._col);
            destination = new Position(destination._row, destination._col);

            if (_array[source._row, source._col] != 0 && _array[destination._row, destination._col] == 0)
            {
                int temp = _array[source._row, source._col];
                _array[source._row, source._col] = _array[destination._row, destination._col];
                _array[destination._row, destination._col] = temp;
            }

        }

    }
}

