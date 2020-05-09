using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Game
{
    public class Field
    {
        public int Height { get; }
        public int Width { get; }
        public int BallsCount { get; }
        public int ColorsCount { get; }
        public int BallsInLineCount { get; }

        readonly BallColor[,] _array;

        public Field() : this(9, 9, 3, 4, 4)
        {
        }

        public Field(int height, int width, int ballsCount, int colorsCount, int ballsInLineCount)
        {
            Height = height;
            Width = width;
            BallsCount = ballsCount;
            ColorsCount = colorsCount;
            BallsInLineCount = ballsInLineCount;
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
            if (listPosition.Count == 0)
            {
                Console.WriteLine("Game is over");
            }
            else
            {
                for (int i = 0; i < BallsCount; i++)
                {
                    var elementIndex = random.Next(listPosition.Count);
                    var position = listPosition[elementIndex];
                    _array[position.Row, position.Column] = (BallColor)random.Next(1, ColorsCount + 1);
                }
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


        public void RemoveLines(Position position)
        {
            var directionHorizontal = new Position[]
            {
                new Position(0, 1), new Position(0, -1),
            };

            var directionVertical = new Position[]
            {
                new Position(1,0), new Position(-1, 0),
            };
            var directionDiagonal = new Position[]
            {
                new Position(-1, -1), new Position(-1, 1),
                new Position(1, -1), new Position(1,1),
            };

            var lineHorizontal = GetLine(position, directionHorizontal);
            var lineVertical = GetLine(position, directionVertical);
            var lineDiagonal = GetLine(position, directionDiagonal);

            if (lineHorizontal.Count >= BallsInLineCount)
            {
                foreach (var ball in lineHorizontal )
                {
                   SetBallColorAt(ball, BallColor.Empty);
                }
            }

            if (lineVertical.Count >= BallsInLineCount)
            {
                foreach (var ball in lineVertical)
                {
                    SetBallColorAt(ball, BallColor.Empty);
                }
            }

            if (lineDiagonal.Count >= BallsInLineCount)
            {
                foreach (var ball in lineDiagonal)
                {
                    SetBallColorAt(ball, BallColor.Empty);
                }
            }
        }

        // TG: implement the function
        public IList<Position> GetLineHorizontal(Position position)
        {
            var directions = new Position[]{new Position(0, 1), new Position(0, -1),
                //new Position(1,0), new Position(-1, 0),
                //new Position(-1, -1), new Position(-1, 1),
                //new Position(1, -1), new Position(1,1),
            };
            return GetLine(position, directions);
        }

        private IList<Position> GetLine(Position position, Position[] directions)
        {
            var color = GetBallColorAt(position);
            var line = new List<Position>{position};

            foreach (var direction in directions)
            {
                var current = position;

                for (;;)
                {
                    current = current + direction;

                    if (current.Column < 0 || current.Column >= Width || current.Row < 0 || current.Row >= Height ||
                        GetBallColorAt(current) != color)
                    {
                        break;
                    }

                    line.Add(current);
                }
            }
            return line;
        }

        internal void SetBallColorAt(Position position, BallColor color)
        {
            _array[position.Row, position.Column] = color;
        }
    }
}

