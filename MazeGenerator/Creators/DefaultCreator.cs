using System;
using System.Collections.Generic;

namespace MazeGenerator.Creators
{
    public class DefaultCreator : ICreator
    {
        #region Constructor

        public DefaultCreator(int corridorBias, int seed, Directions start, Directions end, MazeTypes mazeType, int roomDensity, int roomDistance, int roomMinSize, int roomMaxSize)
        {
            _corridorBias = corridorBias;
            _mazeType = mazeType;

            _startDirection = start;
            _endDirection = end;

            _roomDensity = roomDensity;
            _roomDistance = roomDistance;
            _roomMinSize = roomMinSize;
            _roomMaxSize = roomMaxSize;


            _pathRandomizer = new Random(seed);
            _startEndRandomizer = new Random(seed);
            _roomRandomizer = new Random(seed);
        }

        #endregion

        #region Enumerators

        public enum MazeTypes
        {
            PartialBraid,
            Perfect
        }

        public enum Directions
        {
            Left,
            Right,
            Up,
            Down
        }

        #endregion

        #region Private Fields

        private readonly int _corridorBias;
        private readonly Directions _startDirection;
        private readonly Directions _endDirection;
        private readonly MazeTypes _mazeType;
        private readonly int _roomDensity;
        private readonly int _roomDistance;
        private readonly int _roomMinSize;
        private readonly int _roomMaxSize;


        private Random _pathRandomizer;
        private Random _startEndRandomizer;
        private Random _roomRandomizer;

        #endregion

        #region Interface Methods

        public void Create(Maze maze)
        {
            var rooms = CreateRooms(maze);
            CreatePaths(maze);

            if (_mazeType == MazeTypes.PartialBraid)
                RemoveDeadEnds(maze);

            ConnectRooms(maze, rooms);
        }

        public Position DefineStart(Maze maze)
        {
            int x = 0;
            int y = 0;

            switch (_startDirection)
            {
                default:
                case Directions.Left:
                    x = 0;
                    y = _startEndRandomizer.Next(0, maze.Height);
                    break;
                case Directions.Right:
                    x = maze.Width - 1;
                    y = _startEndRandomizer.Next(0, maze.Height);
                    break;
                case Directions.Up:
                    x = _startEndRandomizer.Next(0, maze.Width);
                    y = 0;
                    break;
                case Directions.Down:
                    x = _startEndRandomizer.Next(0, maze.Width);
                    y = maze.Height - 1;
                    break;
            }

            return Position.Create(x, y);
        }

        public Position DefineFinish(Maze maze)
        {
            int x = 0;
            int y = 0;

            switch (_endDirection)
            {
                default:
                case Directions.Left:
                    x = 0;
                    y = _startEndRandomizer.Next(0, maze.Height);
                    break;
                case Directions.Right:
                    x = maze.Width - 1;
                    y = _startEndRandomizer.Next(0, maze.Height);
                    break;
                case Directions.Up:
                    x = _startEndRandomizer.Next(0, maze.Width);
                    y = 0;
                    break;
                case Directions.Down:
                    x = _startEndRandomizer.Next(0, maze.Width);
                    y = maze.Height - 1;
                    break;
            }

            return Position.Create(x, y);
        }

        #endregion

        #region Private Methods

        #region Room Creation

        private Room CreateRoom(Maze maze)
        {
            var width = _roomRandomizer.Next(_roomMinSize, _roomMaxSize + 1);
            var height = _roomRandomizer.Next(_roomMinSize, _roomMaxSize + 1);

            var xMaxRange = maze.Width - width - _roomDistance;
            var yMaxRange = maze.Height - height - _roomDistance;

            if (xMaxRange < _roomDistance) return null;
            if (yMaxRange < _roomDistance) return null;

            var x = _roomRandomizer.Next(_roomDistance, maze.Width - width - _roomDistance);
            var y = _roomRandomizer.Next(_roomDistance, maze.Height - height - _roomDistance);

            var room = new Room(x, y, width, height);
            return room;
        }

        private void OpenRoom(Maze maze, Room room)
        {
            for (int x = room.Left; x <= room.Right; x++)
                for (int y = room.Top; y <= room.Bottom; y++)
                {
                    var position = Position.Create(x, y);
                    var rightPosition = Position.Create(x + 1, y);
                    var downPosition = Position.Create(x, y + 1);

                    if (rightPosition.X <= room.Right)
                        OpenPath(maze, position, rightPosition, true);
                    if (downPosition.Y <= room.Bottom)
                        OpenPath(maze, position, downPosition, true);
                }
        }

        private List<Room> CreateRooms(Maze maze)
        {
            List<Room> createdRooms = new List<Room>();

            for (int densityCounter = 0; densityCounter < _roomDensity; densityCounter++)
            {
                var room = CreateRoom(maze);
                if (room == null) continue;

                var overlaps = false;
                foreach (var createdRoom in createdRooms)
                    if (room.DistanceTo(createdRoom) < _roomDistance)
                    {
                        overlaps = true;
                        break;
                    }

                if (overlaps)
                    continue;
                else
                {
                    createdRooms.Add(room);
                    OpenRoom(maze, room);
                }
            }

            return createdRooms;
        }

        #endregion

        #region Room Connection

        private void ConnectRooms(Maze maze, List<Room> rooms)
        {
            foreach (var room in rooms)
            {
            }
        }

        #endregion

        #region Path Creation

        private IEnumerable<Position> FindAvailablePositions(Maze maze, Position currentPosition)
        {
            if (currentPosition.Y - 1 >= 0)
            {
                Position nextPosition = Position.Create(currentPosition.X, currentPosition.Y - 1);
                Cell northCell = maze[nextPosition.X, nextPosition.Y];
                if (northCell.IsUnused())
                    yield return nextPosition;
            }

            if (currentPosition.Y + 1 < maze.Height)
            {
                Position nextPosition = Position.Create(currentPosition.X, currentPosition.Y + 1);
                Cell southCell = maze[nextPosition.X, nextPosition.Y];
                if (southCell.IsUnused())
                    yield return nextPosition;
            }

            if (currentPosition.X - 1 >= 0)
            {
                Position nextPosition = Position.Create(currentPosition.X - 1, currentPosition.Y);
                Cell westCell = maze[nextPosition.X, nextPosition.Y];
                if (westCell.IsUnused())
                    yield return nextPosition;
            }

            if (currentPosition.X + 1 < maze.Width)
            {
                Position nextPosition = Position.Create(currentPosition.X + 1, currentPosition.Y);
                Cell eastCell = maze[nextPosition.X, nextPosition.Y];
                if (eastCell.IsUnused())
                    yield return nextPosition;
            }
        }

        private Position FindNextPosition(Maze maze, Position currentPosition, Position lastPosition)
        {
            IEnumerable<Position> availablePositions = FindAvailablePositions(maze, currentPosition);
            List<Position> availablePositionsBuffer = new List<Position>(availablePositions);

            if (availablePositionsBuffer.Count == 0)
                return Position.Empty;

            bool corridor = _pathRandomizer.Next(0, 101) < _corridorBias;

            while (availablePositionsBuffer.Count > 1)
            {
                Position nextPosition = availablePositionsBuffer[_pathRandomizer.Next(0, availablePositionsBuffer.Count)];
                if (corridor == IsCorridor(lastPosition, nextPosition))
                    return nextPosition;
                else
                    availablePositionsBuffer.Remove(nextPosition);
            }

            return availablePositionsBuffer[0];
        }

        private bool IsCorridor(Position positionOne, Position positionTwo)
        {
            return (positionOne.X == positionTwo.X) || (positionOne.Y == positionTwo.Y);
        }

        private void CreatePaths(Maze maze)
        {
            Position currentPosition = Position.Create(0, 0);
            Position nextPosition = Position.Empty;
            Position lastPosition = Position.Empty;

            Queue<Position> queue = new Queue<Position>();
            queue.Enqueue(currentPosition);

            while (queue.Count > 0)
            {
                nextPosition = FindNextPosition(maze, currentPosition, lastPosition);
                if (!nextPosition.IsEmpty())
                {
                    OpenPath(maze, currentPosition, nextPosition, false);
                    queue.Enqueue(nextPosition);

                    lastPosition = currentPosition;
                    currentPosition = nextPosition;
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        lastPosition = Position.Empty;
                        currentPosition = queue.Dequeue();
                    }
                }
            }
        }

        #endregion

        #region Dead End Processing

        private Position FindConnectableCell(Maze maze, Position currentPosition)
        {
            Position northPosition = FindNorthCell(maze, currentPosition);
            Position southPosition = FindSouthCell(maze, currentPosition);
            Position westPosition = FindWestCell(maze, currentPosition);
            Position eastPosition = FindEastCell(maze, currentPosition);

            List<Position> availablePositions = new List<Position>();

            if (IsNorthConnectable(maze, currentPosition, northPosition, westPosition, eastPosition))
                availablePositions.Add(northPosition);
            if (IsSouthConnectable(maze, currentPosition, southPosition, westPosition, eastPosition))
                availablePositions.Add(southPosition);
            if (IsWestConnectable(maze, currentPosition, northPosition, southPosition, westPosition))
                availablePositions.Add(westPosition);
            if (IsEastConnectable(maze, currentPosition, northPosition, southPosition, eastPosition))
                availablePositions.Add(eastPosition);

            if (availablePositions.Count == 0)
                return Position.Empty;

            return availablePositions[_pathRandomizer.Next(0, availablePositions.Count)];
        }

        private Position FindNorthCell(Maze maze, Position currentPosition)
        {
            if (currentPosition.Y - 1 >= 0)
                return Position.Create(currentPosition.X, currentPosition.Y - 1);
            else
                return Position.Empty;
        }

        private Position FindSouthCell(Maze maze, Position currentPosition)
        {
            if (currentPosition.Y + 1 < maze.Height)
                return Position.Create(currentPosition.X, currentPosition.Y + 1);
            else
                return Position.Empty;
        }

        private Position FindWestCell(Maze maze, Position currentPosition)
        {
            if (currentPosition.X - 1 >= 0)
                return Position.Create(currentPosition.X - 1, currentPosition.Y);
            else
                return Position.Empty;
        }

        private Position FindEastCell(Maze maze, Position currentPosition)
        {
            if (currentPosition.X + 1 < maze.Width)
                return Position.Create(currentPosition.X + 1, currentPosition.Y);
            else
                return Position.Empty;
        }

        private bool IsDeadEnd(Cell cell)
        {
            int wallCount = 0;

            if (cell.WestWall) wallCount++;
            if (cell.EastWall) wallCount++;
            if (cell.NorthWall) wallCount++;
            if (cell.SouthWall) wallCount++;

            return wallCount == 3;
        }

        private bool IsNorthConnectable(Maze maze, Position currentPosition, Position northPosition, Position westPosition, Position eastPosition)
        {
            Cell currentCell = maze[currentPosition.X, currentPosition.Y];
            Cell cellNorth = maze[northPosition.X, northPosition.Y];
            Cell cellWest = maze[westPosition.X, westPosition.Y];
            Cell cellEast = maze[eastPosition.X, eastPosition.Y];

            if (!currentCell.NorthWall)
                return false;

            if (cellNorth.IsInvalid())
                return false;

            if (cellNorth.Room)
                return false;

            bool westEndClear = false;
            bool eastEndClear = false;

            if (cellWest.IsInvalid() ||
                cellWest.NorthWall ||
                cellWest.EastWall ||
                cellNorth.WestWall)
                westEndClear = true;

            if (cellEast.IsInvalid() ||
                cellEast.NorthWall ||
                cellEast.WestWall ||
                cellNorth.EastWall)
                eastEndClear = true;

            return westEndClear && eastEndClear;
        }

        private bool IsSouthConnectable(Maze maze, Position currentPosition, Position southPosition, Position westPosition, Position eastPosition)
        {
            Cell currentCell = maze[currentPosition.X, currentPosition.Y];
            Cell cellWest = maze[westPosition.X, westPosition.Y];
            Cell cellEast = maze[eastPosition.X, eastPosition.Y];
            Cell cellSouth = maze[southPosition.X, southPosition.Y];

            if (!currentCell.SouthWall)
                return false;

            if (cellSouth.IsInvalid())
                return false;

            if (cellSouth.Room)
                return false;

            bool westEndClear = false;
            bool eastEndClear = false;

            if (cellWest.IsInvalid() ||
                cellWest.SouthWall ||
                cellWest.EastWall ||
                cellSouth.WestWall)
                westEndClear = true;

            if (cellEast.IsInvalid() ||
                cellEast.SouthWall ||
                cellEast.WestWall ||
                cellSouth.EastWall)
                eastEndClear = true;

            return westEndClear && eastEndClear;
        }

        private bool IsWestConnectable(Maze maze, Position currentPosition, Position northPosition, Position southPosition, Position westPosition)
        {
            Cell currentCell = maze[currentPosition.X, currentPosition.Y];
            Cell cellNorth = maze[northPosition.X, northPosition.Y];
            Cell cellSouth = maze[southPosition.X, southPosition.Y];
            Cell cellWest = maze[westPosition.X, westPosition.Y];

            if (!currentCell.WestWall)
                return false;

            if (cellWest.IsInvalid())
                return false;

            if (cellWest.Room)
                return false;

            bool northEndClear = false;
            bool southEndClear = false;

            if (cellNorth.IsInvalid() ||
                cellNorth.WestWall ||
                cellNorth.SouthWall ||
                cellWest.NorthWall)
                northEndClear = true;

            if (cellSouth.IsInvalid() ||
                cellSouth.NorthWall ||
                cellSouth.WestWall||
                cellWest.SouthWall)
                southEndClear = true;

            return northEndClear && southEndClear;
        }

        private bool IsEastConnectable(Maze maze, Position currentPosition, Position northPosition, Position southPosition, Position eastPosition)
        {
            Cell currentCell = maze[currentPosition.X, currentPosition.Y];
            Cell cellNorth = maze[northPosition.X, northPosition.Y];
            Cell cellSouth = maze[southPosition.X, southPosition.Y];
            Cell cellEast = maze[eastPosition.X, eastPosition.Y];

            if (!currentCell.EastWall)
                return false;

            if (cellEast.IsInvalid())
                return false;

            if (cellEast.Room)
                return false;

            bool northEndClear = false;
            bool southEndClear = false;

            if (cellNorth.IsInvalid() ||
                cellNorth.EastWall ||
                cellNorth.SouthWall ||
                cellEast.NorthWall)
                northEndClear = true;

            if (cellSouth.IsInvalid() ||
                cellSouth.NorthWall ||
                cellSouth.EastWall ||
                cellEast.SouthWall)
                southEndClear = true;

            return northEndClear && southEndClear;
        }

        private void RemoveDeadEnds(Maze maze)
        {
            for (int x = 0; x < maze.Width; x++)
                for (int y = 0; y < maze.Height; y++)
                {
                    if (IsDeadEnd(maze[x, y]))
                    {
                        Position deadEndPosition = Position.Create(x, y);
                        Position neighbourPosition = FindConnectableCell(maze, deadEndPosition);
                        if (!neighbourPosition.IsEmpty())
                            OpenPath(maze, deadEndPosition, neighbourPosition, false);
                    }
                }
        }

        #endregion

        private void OpenPath(Maze maze, Position positionOne, Position positionTwo, bool room)
        {
            Cell cellOne = maze[positionOne.X, positionOne.Y];
            Cell cellTwo = maze[positionTwo.X, positionTwo.Y];

            if (positionOne.X == positionTwo.X)
            {
                if (positionOne.Y > positionTwo.Y)
                {
                    cellOne.NorthWall = positionOne.Y < positionTwo.Y;
                    cellTwo.SouthWall = positionOne.Y < positionTwo.Y;
                    cellOne.Room = room;
                    cellTwo.Room = room;
                }
                else
                {
                    cellOne.SouthWall = positionOne.Y > positionTwo.Y;
                    cellTwo.NorthWall = positionOne.Y > positionTwo.Y;
                    cellOne.Room = room;
                    cellTwo.Room = room;
                }
            }

            if (positionOne.Y == positionTwo.Y)
            {
                if (positionOne.X > positionTwo.X)
                {
                    cellOne.WestWall = false;
                    cellTwo.EastWall = false;
                    cellOne.Room = room;
                    cellTwo.Room = room;
                }
                else
                {
                    cellOne.EastWall = false;
                    cellTwo.WestWall = false;
                    cellOne.Room = room;
                    cellTwo.Room = room;
                }
            }

            maze[positionOne.X, positionOne.Y] = cellOne;
            maze[positionTwo.X, positionTwo.Y] = cellTwo;
        }

        #endregion
    }
}