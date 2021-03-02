namespace MazeGenerator
{
    public struct Position
    {
        #region Public Fields

        public int X;
        public int Y;

        #endregion

        #region Public Methods

        public bool IsEmpty()
        {
            return (X == -1) || (Y == -1);
        }

        public bool IsEqual(Position position)
        {
            return (X == position.X) && (Y == position.Y);
        }

        #endregion

        #region Static Properties

        public static Position Empty
        {
            get
            {
                Position position;
                position.X = -1;
                position.Y = -1;
                return position;
            }
        }

        public static Position Create(int x, int y)
        {
            Position position;
            position.X = x;
            position.Y = y;
            return position;
        }

        #endregion
    }
}