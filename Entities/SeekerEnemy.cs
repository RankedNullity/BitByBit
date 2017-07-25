using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BitByBit.Entities
{
    public class SeekerEnemy : AttackingCharacter
    {
        public override int Damage
        {
            get
            {
                return Level * 5;
            }
        }
        public override int MaxCoolDownFrames
        {
            get
            {
                return 25;
            }
        }
        public Animation enemyWalkLeft = new Animation(new Bitmap(Properties.Resources.Enemy_Left_1),
        new Bitmap(Properties.Resources.Enemy_Left_2),
        new Bitmap(Properties.Resources.Enemy_Left_3),
        new Bitmap(Properties.Resources.Enemy_Left_4),
        new Bitmap(Properties.Resources.Enemy_Left_5),
        new Bitmap(Properties.Resources.Enemy_Left_6),
        new Bitmap(Properties.Resources.Enemy_Left_7));

        public Animation enemyWalkRight = new Animation(new Bitmap(Properties.Resources.Enemy_Right_1),
        new Bitmap(Properties.Resources.Enemy_Right_2),
        new Bitmap(Properties.Resources.Enemy_Right_3),
        new Bitmap(Properties.Resources.Enemy_Right_4),
        new Bitmap(Properties.Resources.Enemy_Right_5),
        new Bitmap(Properties.Resources.Enemy_Right_6),
        new Bitmap(Properties.Resources.Enemy_Right_7));
        public const int PixelsPerFrame = 3;
        public bool movingLeft;

        public SeekerEnemy(Random r, int level)
            : base(r, level)
        {
            hitBox = new CollisionBox(0, 0, 115, 63);
        }
        
    }
}
