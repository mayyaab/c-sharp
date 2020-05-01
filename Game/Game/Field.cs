using System;

namespace Game
{
    public class Field
    {
        // TG: make this parameterized for the constructor
        public const int ballsCount = 3;

        public int Height { get; }
        public int Width { get; }

        readonly BallColor[,] _array;

        //DONE TG: make this parameterized for the constructor
        public int BallsCount ;
        public int ColorsCount;
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

            for (int i = 0; i < BallsCount; i++)
            {
                var elementIndex = random.Next(arrayEmptyPosition.Length);
                var position = arrayEmptyPosition[elementIndex];
                //DONE TG: make number of elements parameterized from the constructor
                _array[position.Row, position.Column] = (BallColor)random.Next(1, ColorsCount+1);
            }
        }

        public void MoveBall(Position source, Position destination)
        {
            //DONE  TG: split to two different conditions
            if (_array[source.Row, source.Column] == 0)
            {
                throw new Exception("empty source");
            }
            if (_array[destination.Row, destination.Column] != 0)
            {
                throw new Exception("busy destination");
            }

            var temp = _array[source.Row, source.Column];
            _array[source.Row, source.Column] = _array[destination.Row, destination.Column];
            _array[destination.Row, destination.Column] = temp;
        }
    }
}

