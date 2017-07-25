using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitByBit.Entities;
using BitByBit.Items;
using System.Drawing;

namespace BitByBit
{
    public class Game
    {
        /*-------------------------Members---------------------*/
        private Cave _cave;
        public static Random _seededGen;
        public int _PlayThroughNum;
        public Player player;
        public List<AttackingCharacter> Enemies = new List<AttackingCharacter>();
        public List<Projectile> projectiles = new List<Projectile>();
        public List<CollisionBox> droppedItems = new List<CollisionBox>();
        public Sound sounds = new Sound();
        public bool firstRoom = true;
        private int caveSize 
        { 
            get 
            { 
                return (4 + _PlayThroughNum) * 4; 
            } 
        }
        private bool RoomCleared
        {
            get
            {
                return _cave.Rooms[_cave.CurrentRoom].EnemiesInRoom == 0;
            }
        }
       
        /*------------------------Constants-----------------------*/

        public const int BOUNDARY_BOT = 560, BOUNDARY_TOP = 90,
            BOUNDARY_LEFT = 90, BOUNDARY_RIGHT = 1113, DOOR_SIZE = 240;
        private const int PROJECTILE_SPEED = 20;
        private const int ENTITY_SIZE = 117;
        private static Graphics screen;
        public CollisionBox[] Doors = new CollisionBox[4]
        {
            new CollisionBox(0, 226 , BOUNDARY_LEFT + 5, DOOR_SIZE),
            new CollisionBox(520, 0 , DOOR_SIZE, BOUNDARY_TOP + 5),
            new CollisionBox(BOUNDARY_RIGHT + 60, 226 , BOUNDARY_LEFT + 5, DOOR_SIZE),
            new CollisionBox(520, BOUNDARY_BOT + 70, DOOR_SIZE, BOUNDARY_TOP + 5)
        };


        /*-----------------------Animations------------------------*/
        public static Bitmap GameBackground = new Bitmap(Properties.Resources.Screen_Cave);
        
        public static Animation wumpus = new Animation(new Bitmap(Properties.Resources.Wumpus_1),
        new Bitmap(Properties.Resources.Wumpus_2),
        new Bitmap(Properties.Resources.Wumpus_1),
        new Bitmap(Properties.Resources.Wumpus_2));

        public static Animation heavyArmorDown = new Animation(new Bitmap(Properties.Resources.Heavy_Down_1),
        new Bitmap(Properties.Resources.Heavy_Down_2),
        new Bitmap(Properties.Resources.Heavy_Down_3),
        new Bitmap(Properties.Resources.Heavy_Down_4),
        new Bitmap(Properties.Resources.Heavy_Down_5),
        new Bitmap(Properties.Resources.Heavy_Down_6));

        public static Animation heavyArmorUp = new Animation(new Bitmap(Properties.Resources.Heavy_Up_1),
        new Bitmap(Properties.Resources.Heavy_Up_2),
        new Bitmap(Properties.Resources.Heavy_Up_3),
        new Bitmap(Properties.Resources.Heavy_Up_1),
        new Bitmap(Properties.Resources.Heavy_Up_2),
        new Bitmap(Properties.Resources.Heavy_Up_3));
        
        public static Animation lightArmorDown = new Animation(new Bitmap(Properties.Resources.Light_Down_1),
        new Bitmap(Properties.Resources.Light_Down_2),
        new Bitmap(Properties.Resources.Light_Down_3),
        new Bitmap(Properties.Resources.Light_Down_4),
        new Bitmap(Properties.Resources.Light_Down_5),
        new Bitmap(Properties.Resources.Light_Down_6));
        
        public static Animation lightArmorUp = new Animation(new Bitmap(Properties.Resources.Light_Up_1),
        new Bitmap(Properties.Resources.Light_Up_2),
        new Bitmap(Properties.Resources.Light_Up_3),
        new Bitmap(Properties.Resources.Light_Up_4),
        new Bitmap(Properties.Resources.Light_Up_5),
        new Bitmap(Properties.Resources.Light_Up_6));

        public static Animation mediumArmorDown = new Animation(new Bitmap(Properties.Resources.Med_Down_1),
        new Bitmap(Properties.Resources.Med_Down_2),
        new Bitmap(Properties.Resources.Med_Down_3),
        new Bitmap(Properties.Resources.Med_Down_4),
        new Bitmap(Properties.Resources.Med_Down_5),
        new Bitmap(Properties.Resources.Med_Down_6));

        public static Animation mediumArmorUp = new Animation(new Bitmap(Properties.Resources.Med_Up_1),
        new Bitmap(Properties.Resources.Med_Up_2),
        new Bitmap(Properties.Resources.Med_Up_3),
        new Bitmap(Properties.Resources.Med_Up_1),
        new Bitmap(Properties.Resources.Med_Up_2),
        new Bitmap(Properties.Resources.Med_Up_3));
        

        /*---------------------Functions-----------------------*/
        public Game(Random r)
        {
            _seededGen = r;
            _cave = new Cave(caveSize, _seededGen);
            player = new Player(_seededGen);
        }

        public void InitEngine(Graphics g)
        {
            screen = g;
        }

        public void DrawEverything()
        {
            if(screen == null)
                return;
            Bitmap frame = new Bitmap(1280, 720);
            Graphics gameGraphics = Graphics.FromImage(frame);
            
            gameGraphics.DrawImage(GameBackground,0,0);
            
            //foreach (CollisionBox door in Doors)
                //gameGraphics.FillRectangle(new SolidBrush(Color.Red), door.x, door.y, door.xMax - door.x, door.yMax - door.y);

            foreach (CollisionBox box in droppedItems)
                gameGraphics.DrawImage(new Bitmap(Properties.Resources.Sprite_ItemDrop,100,100), box.x, box.y);

            if (!(_cave.CurrentRoom == _cave.BossRoom))
            {
                foreach (AttackingCharacter ch in Enemies)
                {
                    if (ch != null)
                    {
                        if (ch is SeekerEnemy)
                        {

                            SeekerEnemy se = ch as SeekerEnemy;
                            if (se.movingLeft)
                            {
                                //gameGraphics.FillRectangle(new SolidBrush(Color.Red), se.hitBox.x, se.hitBox.y, se.hitBox.width, se.hitBox.height);
                                gameGraphics.DrawImage(se.enemyWalkLeft.playAnimation(), se.hitBox.x, se.hitBox.y);
                            }
                            else
                            {
                                //gameGraphics.FillRectangle(new SolidBrush(Color.Red), se.hitBox.x, se.hitBox.y, se.hitBox.width, se.hitBox.height);
                                gameGraphics.DrawImage(se.enemyWalkRight.playAnimation(), se.hitBox.x, se.hitBox.y);
                            }

                        }
                        else if (ch is ShooterEnemy)
                        {
                            ShooterEnemy she = ch as ShooterEnemy;
                            if (she.horizontal)
                            {
                                if (she.facingRight)
                                    gameGraphics.DrawImage(Properties.Resources.Shooter_Right, she.hitBox.x, she.hitBox.y);
                                else
                                    gameGraphics.DrawImage(Properties.Resources.Shootrer_Left, she.hitBox.x, she.hitBox.y);
                            }
                            else
                            {
                                if (she.facingUp)
                                    gameGraphics.DrawImage(Properties.Resources.Shooter_Up, she.hitBox.x, she.hitBox.y);
                                else
                                    gameGraphics.DrawImage(Properties.Resources.Shooter_Down, she.hitBox.x, she.hitBox.y);
                            }
                        }
                        gameGraphics.FillRectangle(new SolidBrush(Color.Red), ch.hitBox.x - 5, ch.hitBox.yMax, HealthBarLength(ch, 70) - 1, 16);
                        gameGraphics.DrawImage(Properties.Resources.HealthBar, ch.hitBox.x - 5, ch.hitBox.yMax);
                    }
                }
            }
            else
            {
                gameGraphics.DrawImage(wumpus.playAnimation(), Enemies[0].hitBox.x, Enemies[0].hitBox.y);
                gameGraphics.FillRectangle(new SolidBrush(Color.Red), Enemies[0].hitBox.x  + 30, Enemies[0].hitBox.yMax, HealthBarLength(Enemies[0], 70) - 1 , 16);
                gameGraphics.DrawImage(Properties.Resources.HealthBar, Enemies[0].hitBox.x + 30, Enemies[0].hitBox.yMax);
            }
            
            
            //gameGraphics.FillRectangle(new SolidBrush(Color.Blue), player.hitBox.x, player.hitBox.y, player.hitBox.width, player.hitBox.height);
            
            //DrawPlayer
            if (!player.isMoving)
            {
                switch (player.charInventory.armorType)
                {
                    case Item.StatTypes.Light:
                        gameGraphics.DrawImage(new Bitmap(Properties.Resources.Light_Down_3), player.hitBox.x, player.hitBox.y);
                        break;
                    case Item.StatTypes.Balanced:
                        gameGraphics.DrawImage(new Bitmap(Properties.Resources.Med_Down_6), player.hitBox.x, player.hitBox.y);
                        break;
                    case Item.StatTypes.Heavy:
                        gameGraphics.DrawImage(new Bitmap(Properties.Resources.Heavy_Down_2), player.hitBox.x, player.hitBox.y);
                        break;
                }
            }
            else
            {
                if (player.isWalkingUp)
                {
                    switch (player.charInventory.armorType)
                    {
                        case Item.StatTypes.Light:
                            gameGraphics.DrawImage(lightArmorUp.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                        case Item.StatTypes.Balanced:
                            gameGraphics.DrawImage(mediumArmorUp.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                        case Item.StatTypes.Heavy:
                            gameGraphics.DrawImage(heavyArmorUp.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                    }
                }
                else
                {
                    switch (player.charInventory.armorType)
                    {
                        case Item.StatTypes.Light:
                            gameGraphics.DrawImage(lightArmorDown.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                        case Item.StatTypes.Balanced:
                            gameGraphics.DrawImage(mediumArmorDown.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                        case Item.StatTypes.Heavy:
                            gameGraphics.DrawImage(heavyArmorDown.playAnimation(), player.hitBox.x, player.hitBox.y);
                            break;
                    }
                }
            }

            gameGraphics.FillRectangle(new SolidBrush(Color.Red), player.hitBox.x - 5, player.hitBox.yMax, HealthBarLength(player,70) - 1, 16);
            gameGraphics.DrawImage(Properties.Resources.HealthBar, player.hitBox.x - 5, player.hitBox.yMax);
            foreach (Projectile p in projectiles)
            {
                p.Translate();
                //gameGraphics.TranslateTransform(p.hitBox.x, p.hitBox.y);
                //gameGraphics.RotateTransform(p.angle);
                if (!p.friendly)
                    gameGraphics.DrawImage(Projectile.enemyProjectile, p.hitBox.x, p.hitBox.y);
                else
                {
                    gameGraphics.DrawImage(p.friendlyProjectile.playAnimation(), p.hitBox.x, p.hitBox.y);
                }
                //gameGraphics.RotateTransform(360 - p.angle);
                //gameGraphics.TranslateTransform(0, 0);

            }
            screen.DrawImage(frame,0,0);
        }

        //Should update after Everytime one Frame renders
        public void Update()
        {
            refreshCoolDowns();
            checkForNewRoom();
            checkForBoundary(player);
            for(int i = 0; i < droppedItems.Count; i++)
            {
                if (player.hitBox.isCollided(droppedItems[i]))
                {
                    player.charInventory.AddRandomItem(player.Level, _PlayThroughNum, _seededGen.Next(0, 100));
                    droppedItems.RemoveAt(i);
                    sounds.playItemPick();
                }
            }
            for(int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles.ElementAt(i).friendly)
                {
                    foreach (AttackingCharacter e in Enemies)
                        if (e.hitBox.isCollided(projectiles[i].hitBox))
                        {
                            player.dealDamage(e);
                            projectiles.Remove(projectiles.ElementAt(i));
                            break;
                        }
                }
                else
                {
                    if (projectiles.ElementAt(i).hitBox.isCollided(player.hitBox))
                    {
                        player.takeDamage(player.Level * 5);
                        projectiles.Remove(projectiles.ElementAt(i--));
                    }
                }
                if (i < projectiles.Count && i >= 0)
                {
                    checkForBoundary(projectiles.ElementAt(i));
                    foreach (bool b in projectiles.ElementAt(i).CanMove)
                        if (!b)
                        {
                            projectiles.Remove(projectiles.ElementAt(i--));
                            break;
                        }
                }
                //
            }
            //Enemy Ai
            foreach (AttackingCharacter e in Enemies)
            {
                if (e is SeekerEnemy)
                {
                    if (e.hitBox.isCollided(player.hitBox))
                    {
                        if (e.CoolDownFrames == 0)
                        {
                            e.dealDamage(player);
                            e.CoolDownFrames = e.MaxCoolDownFrames;
                        }
                        else
                            e.CoolDownFrames--;
                    }

                    if (!(e is Wumpus))
                    {
                        SeekerEnemy se = e as SeekerEnemy;
                        int EnemySpeed = 10;
                        if (player.hitBox.x > e.hitBox.x)
                        {
                            se.movingLeft = false;
                            se.hitBox.x += EnemySpeed;
                        }
                        else if (player.hitBox.x < e.hitBox.x)
                        {
                            se.movingLeft = true;
                            se.hitBox.x -= EnemySpeed;
                        }
                        if (player.hitBox.y > e.hitBox.y - EnemySpeed)
                            se.hitBox.y += EnemySpeed;
                        else if (player.hitBox.y < e.hitBox.y + EnemySpeed)
                            se.hitBox.y -= EnemySpeed;
                    }
                }
                else if (e is ShooterEnemy)
                {
                    if (e.CoolDownFrames == 0)
                    {
                        ShooterEnemy tempEnemy = e as ShooterEnemy;
                        shootAtPlayer(tempEnemy);
                        e.CoolDownFrames = e.MaxCoolDownFrames;
                    }
                }
            }
            //Updates all game variables 
            processCharacters();
            
            //Checks if the Boss Mob is dead
            if (_cave.Rooms[_cave.BossRoom].EnemiesInRoom == 0)
                FinishFloor();


        }
        /// <summary>
        /// Has the player shoot a projectile at the angle
        /// </summary>
        /// <param name="angle"></param>
        public void ShootProjectile(int angle)
        {
            if (!(player.CoolDownFrames == 0))
            {
                player.CoolDownFrames--;
                return;
            }
            player.CoolDownFrames = player.MaxCoolDownFrames;
            getValidAngle(ref angle);
            Projectile projectile = new Projectile(new CollisionBox(player.hitBox.xCenter, player.hitBox.yCenter, 50, 50),
            true, PROJECTILE_SPEED, angle);
            switch (angle)
            {
                case  0:
                    projectile.xVelocity = PROJECTILE_SPEED;
                    projectile.yVelocity = 0;
                    break;
                case 45:
                    projectile.xVelocity = PROJECTILE_SPEED ;
                    projectile.yVelocity = PROJECTILE_SPEED ;
                    break;
                case 90:
                    projectile.xVelocity = 0;
                    projectile.yVelocity = PROJECTILE_SPEED;
                    break;
                case 135:
                    projectile.xVelocity = -PROJECTILE_SPEED ;
                    projectile.yVelocity = PROJECTILE_SPEED ;
                    break;
                case 180:
                    projectile.xVelocity = -PROJECTILE_SPEED;
                    projectile.yVelocity = 0;
                    break;
                case 225:
                    projectile.xVelocity = -PROJECTILE_SPEED ;
                    projectile.yVelocity = -PROJECTILE_SPEED ;
                    break;
                case 270:
                    projectile.xVelocity = 0;
                    projectile.yVelocity = -PROJECTILE_SPEED;
                    break;
                case 315:
                    projectile.xVelocity = PROJECTILE_SPEED;
                    projectile.yVelocity = -PROJECTILE_SPEED;
                    break;
            }

            projectiles.Add(projectile);
        }

        /*--------------Internal Functions-----------------*/

        private int HealthBarLength(BaseCharacter ch, int barLength)
        {
            return ch.CurrentHealth * barLength / ch.MaxHealth;
        }

        private void processCharacters()
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].CurrentHealth <= 0)
                {
                    CollisionBox box = new CollisionBox(Enemies[i].hitBox.x, Enemies[i].hitBox.y, 100, 100);
                    droppedItems.Add(box);
                    player.addXP(Enemies[i].Level * 3);
                    Enemies.Remove(Enemies[i]);
                    i--;
                    _cave.Rooms[_cave.CurrentRoom].EnemiesInRoom--;
                }
            }

        }
       
        //Finished

        /// <summary>
        /// Every Frame, Cooldowns are reduced by one
        /// </summary>
        private void refreshCoolDowns()
        {
            if (!(player.CoolDownFrames == 0))
                player.CoolDownFrames--;
            if (Enemies != null)
            {
                foreach (AttackingCharacter ch in Enemies)
                {
                    if (!(ch.CoolDownFrames == 0))
                        ch.CoolDownFrames--;
                }
            }
        }

        private void shootAtPlayer(ShooterEnemy enemy)
        {
            int horizontaldistance = Math.Abs(player.hitBox.xCenter - enemy.hitBox.xCenter);
            int verticaldistance = Math.Abs(player.hitBox.yCenter - enemy.hitBox.yCenter);
            int angleDegrees;
            double angleRadians;
            if (horizontaldistance == 0)
            {
                if(player.hitBox.yCenter < enemy.hitBox.yCenter)
                    angleDegrees = 270;
                else
                    angleDegrees = 90;
            }
            else
            {       
                angleRadians = Math.Atan(verticaldistance / horizontaldistance);
                angleDegrees = (int)(angleRadians / (2 * Math.PI) * 360); 
            }
            Projectile pew = new Projectile(new CollisionBox(enemy.hitBox.x, enemy.hitBox.y, 40, 40),
                false, PROJECTILE_SPEED, angleDegrees);
            if (player.hitBox.yCenter < enemy.hitBox.yCenter)
            {
                pew.yVelocity *= -1;
                enemy.facingUp = true;
                enemy.horizontal = true;
            }
            else
            {
                enemy.facingUp = false;
                enemy.horizontal = false;
            }
            if (player.hitBox.xCenter < enemy.hitBox.xCenter)
            {
                pew.xVelocity *= -1;
                enemy.facingRight = false;
                enemy.horizontal = false;
            }
            else
            {
                enemy.facingRight = true;
                enemy.horizontal = false;
            }
            projectiles.Add(pew);

        }

        private void getValidAngle(ref int angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;
        }

        /// <summary>
        /// Spawns new Enemies into the Room;
        /// </summary>
        private void spawnEnemies()
        {
            if (_cave.CurrentRoom == _cave.BossRoom)
            {
                Enemies.Add(new Wumpus(_seededGen, player.Level));
                return;
            }
            
            for (int i = 0; i < _cave.Rooms[_cave.CurrentRoom].EnemiesInRoom; i++)
            {
                switch (_seededGen.Next(2))
                {
                    case 0:
                        Enemies.Add(new SeekerEnemy(_seededGen, player.Level));
                        break;
                    case 1:
                        Enemies.Add(new ShooterEnemy(_seededGen, player.Level));
                        break;
                }
                Enemies.ElementAt(i).hitBox.x = _seededGen.Next(BOUNDARY_LEFT, BOUNDARY_RIGHT);
                Enemies.ElementAt(i).hitBox.y = _seededGen.Next(BOUNDARY_TOP, BOUNDARY_BOT);
            }
        }

        private void checkForNewRoom()
        {
            for (int i = 0; i < Doors.Length; i++)
            {
                if(player.hitBox.isCollided(Doors[i]))
                {
                    move((Room.Direction)i);
                    break;
                }
            }
            
        }
        /// <summary>
        /// Resets player coordinates if moves a direction in cave
        /// </summary>
        /// <param name="direction"></param>
        private void move(Room.Direction direction)
        {
            int tempX = player.hitBox.x, tempY = player.hitBox.y;
            switch (direction)
            {
                case Room.Direction.Right:
                    tempX = BOUNDARY_LEFT + 25;
                    break;
                case Room.Direction.Left:
                    tempX = BOUNDARY_RIGHT - 10;
                    break;
                case Room.Direction.Down:
                    tempY = BOUNDARY_TOP + 25;
                    break;
                case Room.Direction.Up: 
                    tempY = BOUNDARY_BOT - 10;
                    break;
                default:
                    break;
            }
            firstRoom = false;
            _cave.move(direction);
            player.ResetTemps(tempX, tempY);
            projectiles.Clear();
            droppedItems.Clear();
            Enemies.Clear();
            spawnEnemies();
        }
        //COMPLETED
        
        /// <summary>
        /// Checks if entity in on border
        /// </summary>
        /// <param name="entity"></param>
        private void checkForBoundary(Entity entity)
        {
            if (entity.hitBox.x <= BOUNDARY_LEFT)
                entity.CanMove[(int)Room.Direction.Left] = false;
            else
                entity.CanMove[(int)Room.Direction.Left] = true;
            if (entity.hitBox.x >= BOUNDARY_RIGHT)
                entity.CanMove[(int)Room.Direction.Right] = false;
            else
                entity.CanMove[(int)Room.Direction.Right] = true;
            if (entity.hitBox.y <= BOUNDARY_TOP)
                entity.CanMove[(int)Room.Direction.Up] = false;
            else
                entity.CanMove[(int)Room.Direction.Up] = true;
            if (entity.hitBox.y >= BOUNDARY_BOT)
                entity.CanMove[(int)Room.Direction.Down] = false;
            else
                entity.CanMove[(int)Room.Direction.Down] = true;
        }
        //COMPLETED

        private void FinishFloor()
        {
            _PlayThroughNum++;
            _cave = new Cave(caveSize, _seededGen);
        }
        //COMPLETED

    }
}
