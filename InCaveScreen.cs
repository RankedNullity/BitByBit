using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BitByBit
{
    public partial class InCaveScreen : Form
    {
        public Form _otherForm;
        public Game game;
        public int i = 0;
        public long startTime;
        private List<Keys> movementKeysHeld = new List<Keys>();
        private List<Keys> shootKeysHeld = new List<Keys>();

        public InCaveScreen(Game game, Form form)
        {
            InitializeComponent();
            this.game = game;
            _otherForm = form;
            game.InitEngine(Canvas.CreateGraphics());
            KeyPreview = true;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
            {
                Console.WriteLine("Down is Released");
                shootKeysHeld.Remove(Keys.K);
            }
            else if (e.KeyCode == Keys.J)
            {
                Console.WriteLine("Left is Released");
                shootKeysHeld.Remove(Keys.J);

            }
            else if (e.KeyCode == Keys.I)
            {
                Console.WriteLine("Up is Released");
                shootKeysHeld.Remove(Keys.I);
            }
            else if (e.KeyCode == Keys.L)
            {
                Console.WriteLine("Right is Released");
                shootKeysHeld.Remove(Keys.L);
            }
            else if (e.KeyCode == Keys.S)
            {
                Console.WriteLine("S is Released");
                movementKeysHeld.Remove(Keys.S);
            }
            else if (e.KeyCode == Keys.A)
            {
                Console.WriteLine("A is Released");
                movementKeysHeld.Remove(Keys.A);
                
            }
            else if (e.KeyCode == Keys.W)
            {
                Console.WriteLine("W is Released");
                movementKeysHeld.Remove(Keys.W);
                game.player.isWalkingUp = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                Console.WriteLine("D is Released");
                movementKeysHeld.Remove(Keys.D);
            }
            if(movementKeysHeld.Count == 0)
                game.player.isMoving = false;

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                if(!movementKeysHeld.Contains(Keys.S))
                {
                    Console.WriteLine("S is Held");
                    game.player.isMoving = true;
                    movementKeysHeld.Add(Keys.S);
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (!movementKeysHeld.Contains(Keys.A))
                {
                    Console.WriteLine("A is Held");
                    game.player.isMoving = true;
                    movementKeysHeld.Add(Keys.A);
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (!movementKeysHeld.Contains(Keys.W))
                {
                    Console.WriteLine("W is Held");
                    game.player.isMoving = true;
                    game.player.isWalkingUp = true;
                    movementKeysHeld.Add(Keys.W);
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (!movementKeysHeld.Contains(Keys.D))
                {
                    Console.WriteLine("D is Held");
                    game.player.isMoving = true;
                    movementKeysHeld.Add(Keys.D);
                }
            }
            else if (e.KeyCode == Keys.K)
            {
                if (!shootKeysHeld.Contains(Keys.K))
                {
                    Console.WriteLine("Down is Held");
                    shootKeysHeld.Add(Keys.K);
                }
            }
            else if (e.KeyCode == Keys.J)
            {
                if (!shootKeysHeld.Contains(Keys.J))
                {
                    Console.WriteLine("Left is Held");
                    shootKeysHeld.Add(Keys.J);
                }
            }
            else if (e.KeyCode == Keys.I)
            {
                if (!shootKeysHeld.Contains(Keys.I))
                {
                    Console.WriteLine("Up is Held");
                    shootKeysHeld.Add(Keys.I);
                }
            }
            else if (e.KeyCode == Keys.L)
            {
                if (!shootKeysHeld.Contains(Keys.L))
                {
                    Console.WriteLine("Right is Held");
                    shootKeysHeld.Add(Keys.L);
                }
            }
            else if (e.KeyCode == Keys.E)
            {
                InventoryScreen screen = new InventoryScreen(this);
                FrameCounter.Stop();
                screen.Show();
                this.Hide();
            }
            else if (e.KeyCode == Keys.Q)
            {
                game.player.usePotion();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        { }


        private void timer1_Tick(object sender, EventArgs e)
        {          
            if (shootKeysHeld.Contains(Keys.I) && shootKeysHeld.Contains(Keys.J))
                game.ShootProjectile(225);
            else if (shootKeysHeld.Contains(Keys.K) && shootKeysHeld.Contains(Keys.J))
                game.ShootProjectile(135);
            else if (shootKeysHeld.Contains(Keys.I) && shootKeysHeld.Contains(Keys.L))
                game.ShootProjectile(315);
            else if (shootKeysHeld.Contains(Keys.K) && shootKeysHeld.Contains(Keys.L))
                game.ShootProjectile(45);
            else if (shootKeysHeld.Contains(Keys.I))
                game.ShootProjectile(270);
            else if (shootKeysHeld.Contains(Keys.K))
                game.ShootProjectile(90);
            else if (shootKeysHeld.Contains(Keys.J))
                game.ShootProjectile(180);
            else if (shootKeysHeld.Contains(Keys.L))
                game.ShootProjectile(0);

            if (movementKeysHeld.Contains(Keys.S) && game.player.CanMove[(int)Room.Direction.Down])
                game.player.movePlayer(Room.Direction.Down);
            if (movementKeysHeld.Contains(Keys.W) && game.player.CanMove[(int)Room.Direction.Up])
                game.player.movePlayer(Room.Direction.Up);
            if (movementKeysHeld.Contains(Keys.A) && game.player.CanMove[(int)Room.Direction.Left])
                game.player.movePlayer(Room.Direction.Left);
            if (movementKeysHeld.Contains(Keys.D) && game.player.CanMove[(int)Room.Direction.Right])
                game.player.movePlayer(Room.Direction.Right);
            if (game.player.unSpentSkillPoints > 0)
            {
                LevelupScreen screen = new LevelupScreen(this);
                game.sounds.playLevelUp();
                screen.Show();
                Hide();
                FrameCounter.Stop();
                movementKeysHeld.Clear();
                shootKeysHeld.Clear();
            }
            if (game.player.CurrentHealth <= 0)
            {
                GameOver death = new GameOver();
                FrameCounter.Stop();
                this.Close();
                death.Show();
                return;
            }
            game.Update();
            game.DrawEverything();
            //CurrentHP.Text = "Current HP: " + game.player.CurrentHealth + " out of " + game.player.MaxHealth;
            //EnemyNum.Text = "Enemies: " + game.Enemies.Count;
            if(i == 0)
                startTime = Environment.TickCount;
            i++;
            if (i == 60)
            {
                i = 0;
                Console.WriteLine("60 Frames in " + (Environment.TickCount - startTime) + " Milliseconds");
            }
        }

        private void Menu_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            _otherForm.Show();
        }
            
        private void LevelUpMenus_Enter(object sender, EventArgs e)
        {

        }

        private void Canvas_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void LevelUp_Click(object sender, EventArgs e)
        {
            LevelupScreen n = new LevelupScreen(this);
            FrameCounter.Stop();
            n.Show();
            this.Hide();
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            game.player.takeDamage(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InventoryScreen screen = new InventoryScreen(this);
            FrameCounter.Stop();
            screen.Show();
            this.Hide();
        }

    }
}
