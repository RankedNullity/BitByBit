using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit
{
    public struct CollisionBox 
    {
        public volatile int x, y;
        public int width, height;

        public CollisionBox(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int xMax
        {
            set
            {
                xMax = value;
                x = value - width;
            }
            get
            {
                return x + width;
            }
        }

        public int yMax
        {
            set
            {
                yMax = value;
                x = value - height;
            }
            get
            {
                return y + height;
            }
        }
        public int xCenter
        {
            set
            {
                xCenter = value;
                x = value - (width / 2);
            }
            get
            {
                return (x + xMax) / 2;
            }
        }
        public int yCenter
        {
            set
            {
                yCenter = value;
                y = value - (height / 2);
            }
            get
            {
                return (y + yMax) / 2;
            }
        }

        public bool isCollided(CollisionBox box)
        {
            if (this.y > box.y - this.height && this.y < box.y + box.height &&
                this.x > box.x - this.width && this.x < box.x + box.width)
                return true;
            return false;
        }
    }
}
