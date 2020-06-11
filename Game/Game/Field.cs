using System;
using System.Collections;
using System.Collections.Generic;

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

        public IEnumerable<Position> PlaceBalls()
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

            return listPosition;
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
            var lines = new List<Line>();

            // collect all lines
            foreach (Line.Direction direction in Enum.GetValues(typeof(Line.Direction)))
            {
                var line = GetLine(position, direction);
                lines.Add(line);
            }

            //remove lines
            foreach (var line in lines)
            {
                if (line.Positions.Count >= BallsInLineCount)
                {
                    foreach (Position ball in line.Positions)
                    {
                        SetBallColorAt(ball, BallColor.Empty);
                    }
                }
            }
        }

        public void RemoveForBalls(IEnumerable<Position> listPositions)
        {
            foreach (var position in listPositions)
            {
                if (GetBallColorAt(position) != BallColor.Empty)
                {
                    RemoveLines(position);
                }
            }
        }

        public IList<Position> GetPath(Position source, Position destination, bool[,] visited)
        {
            if (source == destination)
            {
                return new List<Position>
                {
                    source
                };
            }

            IList<Position> minPath = null;

            foreach (var neighbor in GetNeighbors(source))
            {
                if (!IsVisited(neighbor, visited) && GetBallColorAt(neighbor.Row, neighbor.Column) == BallColor.Empty)
                {
                    visited[neighbor.Row, neighbor.Column] = true;
                    var path = GetPath(neighbor, destination, visited);
                    if (path != null && (minPath == null || minPath.Count > path.Count))
                    {
                        minPath = path;
                    }
                }
            }

            minPath?.Insert(0, source);

            return minPath;
        }

        public IList<Position> GetNeighbors(Position source)
        {
            var neighbors = new List<Position>();

            foreach (var direction in new[]{Line.Direction.Horizontal, Line.Direction.Vertical})
            {
                var directionPositions = GetDirections(direction);

                foreach (var step in new[]{directionPositions.Item1, directionPositions.Item2})
                {
                    var position = source + step;
                    if (IsInField(position))
                    {
                        neighbors.Add(position);
                    }
                }
            }

            return neighbors;
        }

        public bool IsInField(Position position)
        {
            return position.Row >= 0 && position.Row < Width && position.Column >= 0 && position.Column < Height;
        }

        private bool IsVisited(Position position, bool[,] visited)
        {
            return visited[position.Row, position.Column];
        }

        private Tuple<Position, Position> GetDirections(Line.Direction direction)
        {
            // TG: consider simplifying it to array and then use direction as an index in the array.

            if (direction == Line.Direction.Horizontal)
            {
                return new Tuple<Position, Position>(new Position(0, -1), new Position(0, 1));
            }

            if (direction == Line.Direction.Vertical)
            {
                return new Tuple<Position, Position>(new Position(-1, 0), new Position(1, 0));
            }

            if (direction == Line.Direction.Descending)
            {
                return new Tuple<Position, Position>(new Position(-1, -1), new Position(1, 1));
            }

            if (direction == Line.Direction.Ascending)
            {
                return new Tuple<Position, Position>(new Position(1, -1), new Position(-1, 1));
            }

            return null;
        }

        private Line GetLine(Position position, Line.Direction directions)
        {
            var line = GetLine(position, GetDirections(directions));
            return line;
        }

        private Line GetLine(Position position, Tuple<Position, Position> directions)
        {
            var color = GetBallColorAt(position);
            var line = new List<Position> { position };

            foreach (var direction in new[] { directions.Item1, directions.Item2 })
            {
                var current = position;

                for (; ; )
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
            Line newLine = new Line(line);
            return newLine;
        }

        internal void SetBallColorAt(Position position, BallColor color)
        {
            _array[position.Row, position.Column] = color;
        }
    }
}