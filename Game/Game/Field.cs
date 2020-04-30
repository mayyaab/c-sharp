using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace Game
{
    public class Field
    {
        public int Height { get; }
        public int Width { get; }

        readonly BallColor[,] _array;

        const int ballsCount = 3;

        public Field() : this(9, 9)
        {
        }

        public Field(int height, int width)
        {
            Height = height;
            Width = width;

            _array = new BallColor[height, width];
        }

        public BallColor GetColor(Position pos)
        {
            return _array[pos.Row, pos.Column];
        }

        // TG: think about strategies to make the function more effective.
        public void PlaceBalls()
        {
            var random = new Random();

            for (int i = 0; i < ballsCount;)
            {
                var heightElement = random.Next(Height);
                var widthElement = random.Next(Width);
                if (_array[heightElement, widthElement] == 0)
                {
                    _array[heightElement, widthElement] = (BallColor) random.Next(1, 5);
                    i++;
                }
            }
        }

        public void PlaceBalls2()
        {
            var arrayEmptyPosition = new Position[Height * Width];
            var index = 0;
            var random = new Random();
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (_array[row, col] == 0)
                    {
                        arrayEmptyPosition[index] = new Position(row, col);
                    }
                }
            }

            for (int i = 0; i < ballsCount; i++)
            {
                var elementIndex = random.Next(arrayEmptyPosition.Length);
                var position = arrayEmptyPosition[elementIndex];
                _array[position.Row, position.Column] = (BallColor)random.Next(1, 5);
            }
        }

        // TG: reorganize the function to check preconditions first
        public void MoveBall(Position source, Position destination)
        {
            if(!(_array[source.Row, source.Column] != 0 && _array[destination.Row, destination.Column] == 0))
            {
                throw new Exception("empty source or busy destination");
            }

            var temp = _array[source.Row, source.Column];
            _array[source.Row, source.Column] = _array[destination.Row, destination.Column];
            _array[destination.Row, destination.Column] = temp;
        }
    }
}

