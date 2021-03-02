namespace MazeGenerator.Creators
{
    public interface ICreator
    {
        #region Interface Methods

        void Create(Maze maze);

        Position DefineStart(Maze maze);

        Position DefineFinish(Maze maze);

        #endregion
    }
}
