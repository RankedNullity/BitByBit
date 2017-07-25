using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitByBit
{
    public sealed class Cave
    {
        private int caveSize, caveWidth, caveHeight;
        public Room[] Rooms;
        public int CurrentRoom, BossRoom;
        
        public Cave(int caveSize, Random r)
        {
            this.caveSize = caveSize;
            Rooms = new Room[caveSize + 1];
            caveWidth = getClosestToSquareFactor(caveSize);
            caveHeight = caveSize / caveWidth;
            for(int i = 1; i < Rooms.Length; i++)
            {
                int down, up, left = i - 1, right = i + 1;
                if (i % caveWidth == 1)
                    left += caveWidth;
                if (i % caveWidth == 0)
                    right -= caveWidth;
                if (i / (caveWidth + 1) == 0)
                    down = i + caveWidth * (caveHeight - 1);
                else
                    down = i - caveWidth;
                if ((double)i / caveWidth > caveHeight - 1)
                    up = i - ((caveHeight - 1) * caveWidth);
                else
                    up = i + caveWidth;
                Rooms[i] = new Room(left, up, right, down, r.Next(1,4));
            }
            CurrentRoom = r.Next(1, caveSize + 1);
            do
            {
                BossRoom = r.Next(1, caveSize + 1);
            } while (BossRoom == CurrentRoom);
            Rooms[BossRoom].EnemiesInRoom = 1;
            Rooms[CurrentRoom].EnemiesInRoom = 0;
        }

        /// <summary>
        /// Finds the lower value that is closest to the square factor of n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int getClosestToSquareFactor(int n)
        {
            bool works = false;
            int factor = (int)Math.Pow(n, 1.0 / 2.0);;
            while (!works)
            {
                if (n % factor == 0)
                    works = true;
                else
                    factor--;
            }
            return factor;            
        }

        public void move(Room.Direction direction)
        {
            CurrentRoom = Rooms[CurrentRoom].Move(direction);
        }
    }

}