using System.Collections.Generic;

namespace Game.Logic
{
    public class GetPathSimple : IPathStrategy
    {
        Field field = new Field();

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

            foreach (var neighbor in field.GetNeighbors(source))
            {
                if (!field.IsVisited(neighbor, visited) && field.GetBallColorAt(neighbor.Row, neighbor.Column) == BallColor.Empty)
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
    }
}
