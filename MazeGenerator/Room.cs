using System;
using System.Collections.Generic;

namespace MazeGenerator
{
    public class Room
    {
        #region Constructor

        public Room(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        #endregion

        #region Attributes and Properties

        public readonly int X;
        public readonly int Y;
        public readonly int Width;
        public readonly int Height;

        public int Top { get { return Y; } }
        public int Bottom { get { return Y + Height - 1; } }
        public int Left { get { return X; } }
        public int Right { get { return X + Width - 1; } }

        #endregion

        #region Public Methods

        public int DistanceTo(Room room)
        {
            if ((Top >= room.Top && Top <= room.Bottom) &&
                (Left >= room.Left && Left <= room.Right))
                return 0;
            if ((Top >= room.Top && Top <= room.Bottom) &&
                (Right >= room.Left && Right <= room.Right))
                return 0;
            if ((Bottom >= room.Top && Bottom <= room.Bottom) &&
                (Left >= room.Left && Left <= room.Right))
                return 0;
            if ((Bottom >= room.Top && Bottom <= room.Bottom) &&
                (Right >= room.Left && Right <= room.Right))
                return 0;

            if ((room.Top >= Top && room.Top <= Bottom) &&
                (room.Left >= Left && room.Left <= Right))
                return 0;
            if ((room.Top >= Top && room.Top <= Bottom) &&
                (room.Right >= Left && room.Right <= Right))
                return 0;
            if ((room.Bottom >= Top && room.Bottom <= Bottom) &&
                (room.Left >= Left && room.Left <= Right))
                return 0;
            if ((room.Bottom >= Top && room.Bottom <= Bottom) &&
                (room.Right >= Left && room.Right <= Right))
                return 0;

            var xDistance = 0;
            if (X < room.X)
                xDistance = room.Left - Right;
            else
                xDistance = Left - room.Right;

            var yDistance = 0;
            if (Y < room.Y)
                yDistance = room.Top - Bottom;
            else
                yDistance = Top - room.Bottom;

            return Math.Max(xDistance, yDistance);
        }

        public List<Cell> BorderCells(Maze maze)
        {
            List<Cell> cells = new List<Cell>();
            cells.Add(maze[Left, Top]);
            cells.Add(maze[Right, Top]);
            cells.Add(maze[Left, Bottom]);
            cells.Add(maze[Right, Bottom]);

            for (int x = Left + 1; x <= Right - 1; x++)
            {
                cells.Add(maze[x, Top]);
                cells.Add(maze[x, Bottom]);
            }

            for (int y = Top + 1; y <= Bottom - 1; y++)
            {
                cells.Add(maze[Left, y]);
                cells.Add(maze[Right, y]);
            }

            return cells;
        }

        #endregion
    }
}