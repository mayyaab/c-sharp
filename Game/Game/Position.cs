namespace Game
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static Position operator +(Position lhs, Position rhs)
        {
            return new Position(lhs.Row + rhs.Row, lhs.Column + rhs.Column);
        }

        public static bool operator ==(Position v1, Position v2)
        {
            if (ReferenceEquals(v1, v2))
            {
                return true;
            }

            if (ReferenceEquals(v1, null))
            {
                return false;
            }
            if (ReferenceEquals(v2, null))
            {
                return false;
            }

            return v1.Equals(v2);
        }

        public static bool operator !=(Position v1, Position v2)
        {
            return !(v1 == v2);

        }
    }
}
