using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BitByBit.Entities
{
    public class Projectile : Entity
    {
        public double xVelocity, yVelocity;
        private double _totalX, _totalY;
        public int angle;
        public bool friendly;
        public Animation friendlyProjectile;
        public static Bitmap enemyProjectile = new Bitmap(Properties.Resources.EnemyProjectile);
        public override int Damage
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /*public enum ProjType
        {
            Dagger,
            Spear,
            Claymore,
            None
        }*/


        /// <summary>
        /// angle in degrees
        /// </summary>
        /// <param name="box"></param>
        /// <param name="damage"></param>
        /// <param name="velocity"></param>
        /// <param name="angle"></param>
        public Projectile(CollisionBox box, bool friendly, int velocity, int angle)
        {
            hitBox = box;
            this.friendly = friendly;
            this.angle = angle;
            while (angle < 0)
                angle += 360;
            while (angle > 360)
                angle -= 360;
            double angleRadians = angle * Math.PI / 180;
            yVelocity = velocity * Math.Sin(angle);
            xVelocity = velocity * Math.Cos(angle);
            _totalX = box.x;
            _totalY = box.y;
            if (friendly)
            {
                friendlyProjectile = new Animation(new Bitmap(Properties.Resources.Dagger_1),
                            new Bitmap(Properties.Resources.Dagger_2),
                            new Bitmap(Properties.Resources.Dagger_3),
                            new Bitmap(Properties.Resources.Dagger_4),
                            new Bitmap(Properties.Resources.Dagger_5),
                            new Bitmap(Properties.Resources.Dagger_6),
                            new Bitmap(Properties.Resources.Dagger_7),
                            new Bitmap(Properties.Resources.Dagger_8),
                            new Bitmap(Properties.Resources.Dagger_9),
                            new Bitmap(Properties.Resources.Dagger_10),
                            new Bitmap(Properties.Resources.Dagger_11));
                /*switch (type)
                {
                    case ProjType.Claymore:
                        friendlyProjectile = new Animation((Properties.Resources.Claymore_1),
                            new Bitmap(Properties.Resources.Claymore_2),
                            new Bitmap(Properties.Resources.Claymore_3));
                        break;
                    case ProjType.Dagger:
                        
                        break;
                    case ProjType.Spear:
                        friendlyProjectile = new Animation(new Bitmap(Properties.Resources.Spear_1),
                            new Bitmap(Properties.Resources.Spear_2),
                            new Bitmap(Properties.Resources.Spear_3),
                            new Bitmap(Properties.Resources.Spear_4),
                            new Bitmap(Properties.Resources.Spear_5),
                            new Bitmap(Properties.Resources.Spear_6));
                        break;
                    default:
                        break;*/
                
            }
        }

        /// <summary>
        /// One call of the method translates the projectile with the corresponding vectors
        /// </summary>
        public void Translate()
        {
            _totalX += xVelocity;
            _totalY += yVelocity;
            hitBox.x = (int)_totalX;
            hitBox.y = (int)_totalY; 
        }

    }
}
