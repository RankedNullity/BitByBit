using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    class ShooterEnemy : AttackingCharacter
    {
        public override int MaxCoolDownFrames
        {
            get
            {
                return 25;
            }
        }

        public override int Damage
        {
            get
            {
                return Level * 5;
            }
        }
        public bool facingUp, facingRight, horizontal;
        public ShooterEnemy(Random r, int level)
            : base(r, level)
        {
            hitBox = new CollisionBox(0, 0, 60, 60);
        }
    }
        
}
