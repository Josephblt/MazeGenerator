using System.Collections.ObjectModel;

namespace MazeGenerator.Solvers
{
    public interface ISolver
    {
        #region Interface Methods

        ReadOnlyCollection<Position> Solve(Maze maze);

        #endregion
    }
}
