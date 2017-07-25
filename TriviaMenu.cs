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
    public partial class TriviaMenu : Form
    {
        private Game _game;
        public TriviaMenu(Game game)
        {
            InitializeComponent();
            _game = game;
            upDate();
        }
        private void upDate()
        {
            Game._seededGen.Next(9);
            //label1.Text = _game.trivia.Questions
        }
    }
}
