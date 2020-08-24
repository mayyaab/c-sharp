﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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

        // TG: lets implement an alternative algorithm as Strategy pattern
        // https://www.dofactory.com/net/strategy-design-pattern
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

        public List<Position> GetPathWave(Position source, Position destination)
        {
            /* Распространение волны

            ЦИКЛ
                ДЛЯ каждой ячейки loc, помеченной числом d
            пометить все соседние свободные непомеченные ячейки числом d + 1
            КЦ
            d := d + 1
            ПОКА(финишная ячейка не помечена) И(есть возможность распространения волны)

            Восстановление пути

            ЕСЛИ финишная ячейка помечена
            ТО
            перейти в финишную ячейку
            ЦИКЛ
            выбрать среди соседних ячейку, помеченную числом на 1 меньше числа в текущей ячейке
            перейти в выбранную ячейку и добавить её к пути
            ПОКА текущая ячейка — не стартовая
            ВОЗВРАТ путь найден
            ИНАЧЕ
            ВОЗВРАТ путь не найден
             */

            bool[,] visited = new bool[Height, Width];

            var visitedPositions = new Queue<List<Position>>();
            var sourceQueue = new List<Position>();
            sourceQueue.Add(source);
            visitedPositions.Enqueue(sourceQueue);

            while (visitedPositions.Count != 0)
            {
                var path = visitedPositions.Dequeue();

                var element = path.Last();
                if (element == destination)
                {
                    return path;
                }
                visited[element.Row, element.Column] = true;

                var neighbors = GetNeighbors(element);

                foreach (var neighbor in neighbors)
                    if (!visited[neighbor.Row, neighbor.Column])
                    {
                        var list = new List<Position>(path);
                        list.Add(neighbor);
                        visitedPositions.Enqueue(list);
                    }
            }
            return null;
        }

        public bool GetPathWaveOriginal(Position source, Position destination)
        {
            int[,] visited = new int[Height, Width];
            var loc = source;
            int step = 0;

            while (visited[Width, Height] == 0)
            {
                if (visited[destination.Row, destination.Column] != 0)
                {
                    return GetPathBack(source, destination, visited);
                }
                var neighbors = GetNeighbors(loc);
                step++;
                foreach (var neighbor in neighbors)
                {
                    if (visited[neighbor.Row, neighbor.Column] == 0)
                    {
                        visited[neighbor.Row, neighbor.Column] = step;
                        loc = neighbor;
                    }
                }
            }
            return false;
        }

        private bool GetPathBack(Position source, Position destination, int[,] visited)
        {

            while (destination == source)
            {
                var neighbors = GetNeighbors(destination);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor == source)
                    {
                        return true;
                    }
                    if (visited[neighbor.Row, neighbor.Column] - 1 == visited[destination.Row, destination.Column])
                    {
                        destination = neighbor;
                    }
                }
            }
            return false;
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

    public IEnumerable<Position> RemoveLines(Position position)
    {
        var lines = new List<Line>();
        IEnumerable<Position> removedLine = null;

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
                removedLine = new List<Position>(line.Positions);
                foreach (Position ball in line.Positions)
                {
                    SetBallColorAt(ball, BallColor.Empty);
                }
            }
        }

        return removedLine;
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

    internal IList<Position> GetNeighbors(Position source)
    {
        var neighbors = new List<Position>();

        foreach (var direction in new[] { Line.Direction.Horizontal, Line.Direction.Vertical })
        {
            var directionPositions = GetDirections(direction);

            foreach (var step in new[] { directionPositions.Item1, directionPositions.Item2 })
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

    internal bool IsInField(Position position)
    {
        return position.Row >= 0 && position.Row < Width && position.Column >= 0 && position.Column < Height;
    }

    internal bool IsVisited(Position position, bool[,] visited)
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