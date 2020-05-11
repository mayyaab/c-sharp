namespace Game
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public enum Direction
        {
            Horizontal,
            Vertical,
            Descending,
            Ascending
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static Position operator + (Position lhs, Position rhs)
        {
            return new Position(lhs.Row + rhs.Row, lhs.Column + rhs.Column);
        }
    }
}
