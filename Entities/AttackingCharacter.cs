using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    public abstract class AttackingCharacter : BaseCharacter
    {
        public volatile int CoolDownFrames;
        public abstract int MaxCoolDownFrames { get; }
        public AttackingCharacter(Random r, int Level)
            : base(r, Level)
        {
            CoolDownFrames = 0;
        }
    }
}
