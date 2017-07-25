using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    public abstract class Entity
    {
        public CollisionBox hitBox;
        public volatile bool[] CanMove = new bool[4] { true, true, true, true };
        public abstract int Damage { get; }
    }
}
