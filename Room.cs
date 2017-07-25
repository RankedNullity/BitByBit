using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit
{
    public struct Room
    {
        public enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }
        private int leftRoom, topRoom, rightRoom, downRoom;
        public int EnemiesInRoom;
        public Room(int l, int t, int r, int d, int e)
        {
            leftRoom = l;
            topRoom = t;
            rightRoom = r;
            downRoom = d;
            EnemiesInRoom = e;
        }
        public int Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return downRoom;
                case Direction.Left:
                    return leftRoom;
                case Direction.Right:
                    return rightRoom;
                case Direction.Up:
                    return topRoom;
            }
            return 0;
        }
    }
}
