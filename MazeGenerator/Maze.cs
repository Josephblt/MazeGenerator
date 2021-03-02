using MazeGenerator.Creators;
using MazeGenerator.Solvers;
using System.Collections.ObjectModel;

namespace MazeGenerator
{
    public class Maze
    {
        #region Constructor

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[Width, Height];
        }

        #endregion

        #region Attributes and Properties

        public readonly int Width;
        public readonly int Height;

        public ReadOnlyCollection<Position> Solution { get; private set; }
        public Position Start { get; private set; }
        public Position Finish { get; private set; }

        public Cell this[int x, int y]
        {
            get
            {
                if ((x >= Width) || (y >= Height) || (x < 0) || (y < 0)) 
                    return Cell.Invalid;

                return _cells[x, y];
            }
            set
            {
                if ((x >= Width) || (y >= Height) || (Width < 0) || (Height < 0))
                    return;

                _cells[x, y] = value;
            }
        }

        #endregion

        #region Private Fields

        private Cell[,] _cells;

        #endregion

        #region Private Methods

        private void InitializeMaze()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    _cells[x, y] = Cell.Unused;
        }

        #endregion

        #region Public Methods

        public void Create(ICreator creator)
        {
            InitializeMaze();
            creator.Create(this);

            Start = creator.DefineStart(this);
            Finish = creator.DefineFinish(this);
        }

        public void Solve(ISolver solver)
        {
            Solution = solver.Solve(this);
        }

        #endregion
    }
}