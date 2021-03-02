using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MazeGenerator.Solvers
{
    public class DefaultSolver : ISolver
    {
        #region Contructor

        public DefaultSolver()
        {
        }

        #endregion

        #region Classes

        private class DepthPositionTuple
        {
            #region Attributes and Properties

            public int Depth { get; set; }
            public Position Position { get; set; }

            #endregion
        }

        #endregion

        #region Private Fields

        public int[,] _weights;

        #endregion

        #region Interface Methods

        public ReadOnlyCollection<Position> Solve(Maze maze)
        {
            Initialize(maze);
            CalculateWeights(maze);

            List<Position> solutionBuffer = new List<Position>(CalculateShortestPath(maze));
            //List<Position> solutionBuffer = new List<Position>();
            ReadOnlyCollection<Position> solution = new ReadOnlyCollection<Position>(solutionBuffer);
            return solution;
        }

        #endregion

        #region Private Methods

        private void Initialize(Maze maze)
        {
            _weights = new int[maze.Width, maze.Height];

            for (int x = 0; x < maze.Width; x++)
                for (int y = 0; y < maze.Height; y++)
                    _weights[x, y] = -1;
        }

        private void CalculateWeights(Maze maze)
        {
            Queue<DepthPositionTuple> queue = new Queue<DepthPositionTuple>();
            queue.Enqueue(new DepthPositionTuple { Depth = 0, Position = maze.Start });

            while(queue.Count > 0)
            {
                DepthPositionTuple depthPositionTuple = queue.Dequeue();

                int depth = depthPositionTuple.Depth;
                Position currentPosition = depthPositionTuple.Position;

                _weights[currentPosition.X, currentPosition.Y] = depth;

                IEnumerable<Position> neighbours = FindNeighbourPositions(maze, currentPosition);
                foreach (Position neighbourPosition in neighbours)
                    if (_weights[neighbourPosition.X, neighbourPosition.Y] == -1)
                        queue.Enqueue(new DepthPositionTuple { Depth = depth + 1, Position = neighbourPosition });
            }
        }

        private IEnumerable<Position> CalculateShortestPath(Maze maze)
        {
            return CalculateShortestPath(maze, maze.Finish);
        }

        private IEnumerable<Position> CalculateShortestPath(Maze maze, Position currentPosition)
        {
            if (currentPosition.IsEqual(maze.Start))
                yield break;

            Position smallestWeightNeighbour = FindSmallestWeightPosition(maze, currentPosition);
            foreach (var nextPosition in CalculateShortestPath(maze, smallestWeightNeighbour))
                yield return nextPosition;
            yield return currentPosition;
        }

        private IEnumerable<Position> FindNeighbourPositions(Maze maze, Position currentPosition)
        {
            Cell cell = maze[currentPosition.X, currentPosition.Y];

            if (!cell.NorthWall)
                yield return Position.Create(currentPosition.X, currentPosition.Y - 1);

            if (!cell.SouthWall)
                yield return Position.Create(currentPosition.X, currentPosition.Y + 1);

            if (!cell.WestWall)
                yield return Position.Create(currentPosition.X - 1, currentPosition.Y);

            if (!cell.EastWall)
                yield return Position.Create(currentPosition.X + 1, currentPosition.Y);
        }

        private Position FindSmallestWeightPosition(Maze maze, Position currentPosition)
        {
            int minWeight = (maze.Width * maze.Height) + 1;
            Position smallestWeightPosition = Position.Empty;
            Cell cell = maze[currentPosition.X, currentPosition.Y];

            if (!cell.NorthWall)
            {
                Position northPosition = Position.Create(currentPosition.X, currentPosition.Y - 1);
                int northWeight = _weights[northPosition.X, northPosition.Y];

                if (northWeight < minWeight)
                {
                    minWeight = northWeight;
                    smallestWeightPosition = northPosition;
                }
            }

            if (!cell.SouthWall)
            {
                Position southPosition = Position.Create(currentPosition.X, currentPosition.Y + 1);
                int southWeight = _weights[southPosition.X, southPosition.Y];

                if (southWeight < minWeight)
                {
                    minWeight = southWeight;
                    smallestWeightPosition = southPosition;
                }
            }

            if (!cell.WestWall)
            {
                Position westPosition = Position.Create(currentPosition.X - 1, currentPosition.Y);
                int westWeight = _weights[westPosition.X, westPosition.Y];

                if (westWeight < minWeight)
                {
                    minWeight = westWeight;
                    smallestWeightPosition = westPosition;
                }
            }

            if (!cell.EastWall)
            {
                Position eastPosition = Position.Create(currentPosition.X + 1, currentPosition.Y);
                int eastWeight = _weights[eastPosition.X, eastPosition.Y];

                if (eastWeight < minWeight)
                {
                    minWeight = eastWeight;
                    smallestWeightPosition = eastPosition;
                }
            }

            return smallestWeightPosition;
        }

        #endregion
    }
}
