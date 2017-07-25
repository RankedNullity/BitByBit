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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Close();
            menu.Show();
        }
    }
}
