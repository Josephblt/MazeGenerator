using MazeGenerator.Creators;
using MazeGenerator.Solvers;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGenerator.Util
{
    public partial class MainWindow : Form
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        #endregion

        #region Constants

        public const int MARGIN = 12;

        #endregion

        #region Private Fields

        private MazeToolbox _mazeToolbox;

        private Maze _maze;

        private RectangleF _mazeBorderRectangle;
        private RectangleF _mazeInnerRectangle;
        private RectangleF _mazeOutterRectangle;

        private float _cellSize;

        private float _centerFactorX;
        private float _centerFactorY;

        #endregion

        #region Private Methods

        private void InitializeWindow()
        {
            _mazeToolbox = new MazeToolbox();
            _mazeToolbox.CreateCalled += new MazeToolbox.CreateCalledHandler(_mazeToolbox_CreateCalled);
            _mazeToolbox.Show(this);
            _mazeToolbox.Focus();

            RefreshWindow();
        }

        private void RefreshWindow()
        {
            _mazeInnerRectangle = new RectangleF(18f, 18f, ClientRectangle.Width - 36f, ClientRectangle.Height - 36f);
            _mazeOutterRectangle = new RectangleF(12f, 12f, ClientRectangle.Width - 24f, ClientRectangle.Height - 24f);
            _mazeBorderRectangle = new RectangleF(11f, 11f, ClientRectangle.Width - 24f + 1f, ClientRectangle.Height - 24f + 1f);

            if (_maze != null)
            {
                if (_maze.Width > _maze.Height)
                {
                    _cellSize = _mazeInnerRectangle.Width / _maze.Width;
                    if (_cellSize * _maze.Height > _mazeInnerRectangle.Height)
                        _cellSize = _mazeInnerRectangle.Height / _maze.Height;
                }
                else
                {
                    _cellSize = _mazeInnerRectangle.Height / _maze.Height;
                    if (_cellSize * _maze.Width > _mazeInnerRectangle.Width)
                        _cellSize = _mazeInnerRectangle.Width / _maze.Width;
                }

                _centerFactorX = _mazeInnerRectangle.Width / 2f - _maze.Width * _cellSize / 2f + _mazeInnerRectangle.X;
                _centerFactorY = _mazeInnerRectangle.Height / 2f - _maze.Height * _cellSize / 2f + _mazeInnerRectangle.Y;
            }
        }

        private void Create(int width, 
                            int height, 
                            int corridorBias, 
                            int seed, 
                            DefaultCreator.Directions start,
                            DefaultCreator.Directions end,
                            DefaultCreator.MazeTypes mazeType,
                            int roomDensity,
                            int roomDistance,
                            int roomMinSize,
                            int roomMaxSize)
        {
            _maze = new Maze(width, height);
            _maze.Create(new DefaultCreator(corridorBias, seed, start, end, mazeType, roomDensity, roomDistance, roomMinSize, roomMaxSize));
            _maze.Solve(new DefaultSolver());

            Refresh();
        }

        private void DrawCanvas(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.DimGray, _mazeOutterRectangle);
            graphics.DrawRectangle(Pens.Black, _mazeBorderRectangle.X, _mazeBorderRectangle.Y, _mazeBorderRectangle.Width, _mazeBorderRectangle.Height);
        }

        private void DrawMaze(Graphics graphics)
        {
            if (_maze == null) return;

            for (int x = 0; x < _maze.Width; x++)
                for (int y = 0; y < _maze.Height; y++)
                {
                    Cell cell = _maze[x, y];

                    PointF tlPosition = new PointF((x * _cellSize) + _centerFactorX, y * _cellSize + _centerFactorY);
                    PointF trPosition = new PointF((x * _cellSize) + _cellSize + _centerFactorX, (y * _cellSize) + _centerFactorY);
                    PointF blPosition = new PointF((x * _cellSize) + _centerFactorX, (y * _cellSize) + _cellSize + _centerFactorY);
                    PointF brPosition = new PointF((x * _cellSize) + _cellSize + _centerFactorX, (y * _cellSize) + _cellSize + _centerFactorY);

                    if (cell.WestWall)
                        graphics.DrawLine(Pens.Blue, tlPosition, blPosition);

                    if (cell.EastWall)
                        graphics.DrawLine(Pens.Blue, trPosition, brPosition);

                    if (cell.NorthWall)
                        graphics.DrawLine(Pens.Blue, tlPosition, trPosition);

                    if (cell.SouthWall)
                        graphics.DrawLine(Pens.Blue, blPosition, brPosition);
                }
        }

        private void DrawSolution(Graphics graphics)
        {
            if (_maze == null) return;
            if (_maze.Solution == null) return;

            foreach (Position position in _maze.Solution)
            {
                PointF tlPosition = new PointF(position.X * _cellSize + _centerFactorX, position.Y * _cellSize + _centerFactorY);
                graphics.FillRectangle(new SolidBrush(Color.SlateGray), tlPosition.X, tlPosition.Y, _cellSize, _cellSize);
            }
        }

        private void DrawStartFinishCells(Graphics graphics)
        {
            if (_maze == null) return;

            PointF startTLPosition = new PointF(_maze.Start.X * _cellSize + _centerFactorX, _maze.Start.Y * _cellSize + _centerFactorY);
            PointF finishTLPosition = new PointF(_maze.Finish.X * _cellSize + _centerFactorX, _maze.Finish.Y * _cellSize + _centerFactorY);

            graphics.FillRectangle(new SolidBrush(Color.LightBlue), startTLPosition.X, startTLPosition.Y, _cellSize, _cellSize);
            graphics.FillRectangle(new SolidBrush(Color.Green), finishTLPosition.X, finishTLPosition.Y, _cellSize, _cellSize);
        }

        #endregion

        #region Signed Events Methods

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            RefreshWindow();
            DrawCanvas(e.Graphics);
            DrawSolution(e.Graphics);
            DrawStartFinishCells(e.Graphics);
            DrawMaze(e.Graphics);
        }

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void _mazeToolbox_CreateCalled(int width, 
                                               int height, 
                                               int run, 
                                               int seed, 
                                               DefaultCreator.Directions start,
                                               DefaultCreator.Directions end,
                                               DefaultCreator.MazeTypes type,
                                               int roomDensity,
                                               int roomDistance,
                                               int roomMinSize,
                                               int roomMaxSize)
        {
            Create(width, height, run, seed, start, end, type, roomDensity, roomDistance, roomMinSize, roomMaxSize);
        }

        #endregion
    }
}