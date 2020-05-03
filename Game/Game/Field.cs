using System;
using System.Collections.Generic;

namespace Game
{
    public class Field
    {
        public int Height { get; }
        public int Width { get; }

        // TG: make the properties
        public int BallsCount;
        public int ColorsCount;

        readonly BallColor[,] _array;

        public Field() : this(9, 9, 3, 4)
        {
        }

        public Field(int height, int width, int ballsCount, int colorsCount)
        {
            Height = height;
            Width = width;
            BallsCount = ballsCount;
            ColorsCount = colorsCount;
            _array = new BallColor[height, width];
        }

        public BallColor GetBallColorAt(Position pos)
        {
            return GetBallColorAt(pos.Row, pos.Column);
        }

        public BallColor GetBallColorAt(int row, int column)
        {
            return _array[row, column];
        }

        // TG: think about strategies to make the function more effective.
        public void PlaceBalls()
        {
            var random = new Random();

            for (int i = 0; i < BallsCount;)
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
            var listPosition = new List<Position>();

            var random = new Random();
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (_array[row, col] == 0)
                    {
                        listPosition.Add(new Position(row, col));
                    }
                }
            }

            for (int i = 0; i < BallsCount; i++)
            {
                var elementIndex = random.Next(listPosition.Count);
                var position = listPosition[elementIndex];
                _array[position.Row, position.Column] = (BallColor)random.Next(1, ColorsCount+1);
            }
        }

        public void MoveBall(Position source, Position destination)
        {
            if (_array[source.Row, source.Column] == 0)
            {
                throw new Exception("The source square is empty.");
            }
            if (_array[destination.Row, destination.Column] != 0)
            {
                throw new Exception("The destination square is occupied.");
            }

            var temp = _array[source.Row, source.Column];
            _array[source.Row, source.Column] = _array[destination.Row, destination.Column];
            _array[destination.Row, destination.Column] = temp;
        }

        // TG: implement the function
        public IList<Position> GetLineHorizontal(Position position)
        {
            return new List<Position>();
        }

        internal void SetBallColorAt(Position position, BallColor color)
        {
            _array[position.Row, position.Column] = color;
        }
    }
}

