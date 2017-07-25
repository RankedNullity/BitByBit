using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BitByBit
{
    public partial class MainMenu : Form
    {
        private InCaveScreen _GameScreen;
        Game game;
        public int Seed;

        public MainMenu()
        {
            InitializeComponent();
            Random r = new Random();
            Seed = r.Next();
            Random gen = new Random(Seed);
            game = new Game(gen);
            _GameScreen = new InCaveScreen(game, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AllocConsole();
            game.sounds.playMenu();
        }

        private void GameWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        //Allows command line to be seen during normal execution
        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Hide();
            _GameScreen.Show();
            game.sounds.stopMenu();
            game.sounds.playTheme();
            _GameScreen.FrameCounter.Start();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
