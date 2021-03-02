namespace MazeGenerator
{
    public struct Cell
    {
        #region Public Fields

        public bool NorthWall;
        public bool SouthWall;
        public bool WestWall;
        public bool EastWall;

        public bool Room;

        #endregion

        #region Private Fields

        private bool _invalid;

        #endregion

        #region Public Methods

        public bool IsInvalid()
        {
            return _invalid;
        }

        public bool IsUnused()
        {
            return !_invalid &&
                    NorthWall &&
                    SouthWall &&
                    WestWall &&
                    EastWall;
        }

        #endregion

        #region Static Properties

        public static Cell Invalid
        {
            get
            {
                Cell cell = new Cell();
                cell.NorthWall = false;
                cell.SouthWall = false;
                cell.WestWall = false;
                cell.EastWall = false;
                cell._invalid = true;
                return cell;
            }
        }

        public static Cell Unused
        {
            get
            {
                Cell cell = new Cell();
                cell.NorthWall = true;
                cell.SouthWall = true;
                cell.WestWall = true;
                cell.EastWall = true;
                cell._invalid = false;
                return cell;
            }
        }

        #endregion
    }
}
