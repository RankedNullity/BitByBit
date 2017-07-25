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
    public partial class LevelupScreen : Form
    {
        private InCaveScreen _otherForm;
        public LevelupScreen(InCaveScreen screen)
        {
            InitializeComponent();
            _otherForm = screen;
            _otherForm.game.player.addXP(1000);
            upDateScreen();
            var pos = this.PointToScreen(UnspentLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            UnspentLabel.Parent = pictureBox1;
            UnspentLabel.Location = pos;
            UnspentLabel.BackColor = Color.Transparent;

            pos = this.PointToScreen(HealthLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            HealthLabel.Parent = pictureBox1;
            HealthLabel.Location = pos;
            HealthLabel.BackColor = Color.Transparent;

            pos = this.PointToScreen(AttackLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            AttackLabel.Parent = pictureBox1;
            AttackLabel.Location = pos;
            AttackLabel.BackColor = Color.Transparent;

            pos = this.PointToScreen(SpeedLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            SpeedLabel.Parent = pictureBox1;
            SpeedLabel.Location = pos;
            SpeedLabel.BackColor = Color.Transparent;

            pos = this.PointToScreen(AtkSpeedLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            AtkSpeedLabel.Parent = pictureBox1;
            AtkSpeedLabel.Location = pos;
            AtkSpeedLabel.BackColor = Color.Transparent;

        }

        private void HealthUp_Click(object sender, EventArgs e)
        {
            _otherForm.game.player.assignSkillPoint(Entities.BaseCharacter.StatTypes.MaxHealth);
            upDateScreen();
        }

        private void AtkUp_Click(object sender, EventArgs e)
        {
            _otherForm.game.player.assignSkillPoint(Entities.BaseCharacter.StatTypes.Damage);
            upDateScreen();
        }

        private void SpeedUp_Click(object sender, EventArgs e)
        {
            _otherForm.game.player.assignSkillPoint(Entities.BaseCharacter.StatTypes.Speed);
            upDateScreen();
        }

        private void AtkSpeedUp_Click(object sender, EventArgs e)
        {
            _otherForm.game.player.assignSkillPoint(Entities.BaseCharacter.StatTypes.AtkSpeed);
            upDateScreen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void upDateScreen()
        {
            if (_otherForm.game.player.unSpentSkillPoints == 0)
            {
                this.Close();
                _otherForm.Show();
                _otherForm.FrameCounter.Start();
            }
            UnspentLabel.Text = _otherForm.game.player.unSpentSkillPoints.ToString();
            HealthLabel.Text = _otherForm.game.player.BaseStat[(int)Entities.BaseCharacter.StatTypes.MaxHealth].ToString();
            AttackLabel.Text = _otherForm.game.player.BaseStat[(int)Entities.BaseCharacter.StatTypes.Damage].ToString();
            SpeedLabel.Text = (_otherForm.game.player.BaseStat[(int)Entities.BaseCharacter.StatTypes.Speed] / 100.0).ToString();
            AtkSpeedLabel.Text = (_otherForm.game.player.BaseStat[(int)Entities.BaseCharacter.StatTypes.AtkSpeed] / 100.0).ToString();
        }

        private void HealthLabel_Click(object sender, EventArgs e)
        {

        }


    }
}
