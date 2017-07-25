using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    class Wumpus : SeekerEnemy
    {
        public Wumpus(Random r, int Level)
            : base(r, Level)
        {
            BaseStat[(int)StatTypes.MaxHealth] = Level * 100;
            CurrentHealth = Level * 100;
            hitBox = new CollisionBox((Game.BOUNDARY_LEFT + Game.BOUNDARY_RIGHT) / 2, (Game.BOUNDARY_TOP + Game.BOUNDARY_BOT) / 2, 200, 110);
        }
        public override int Damage
        {
            get
            {
                return Level * 100;
            }
        }
    }
}
