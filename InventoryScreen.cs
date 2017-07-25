using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BitByBit.Entities;
using BitByBit.Items;

namespace BitByBit
{
    public partial class InventoryScreen : Form
    {
        private InCaveScreen _GameScreen;
        //private System.Windows.Forms.PictureBox[] InventorySlots;
        public InventoryScreen(InCaveScreen screen)
        {
            InitializeComponent();
            _GameScreen = screen;
            pictureBox0.Parent = MenuPic;
            pictureBox0.BackColor = Color.Transparent;
            pictureBox1.Parent = MenuPic;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.Parent = MenuPic;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Parent = MenuPic;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Parent = MenuPic;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Parent = MenuPic;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Parent = MenuPic;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Parent = MenuPic;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Parent = MenuPic;
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Parent = MenuPic;
            pictureBox10.BackColor = Color.Transparent;
            pictureBox10.Parent = MenuPic;
            pictureBox11.BackColor = Color.Transparent;
            pictureBox11.Parent = MenuPic;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox12.Parent = MenuPic;
            pictureBox13.BackColor = Color.Transparent;
            pictureBox13.Parent = MenuPic;
            pictureBox14.BackColor = Color.Transparent;
            pictureBox14.Parent = MenuPic;
            pictureBox15.BackColor = Color.Transparent;
            pictureBox15.Parent = MenuPic;
            pictureBox16.BackColor = Color.Transparent;
            pictureBox16.Parent = MenuPic;
            pictureBox17.BackColor = Color.Transparent;
            pictureBox17.Parent = MenuPic;
            pictureBox18.BackColor = Color.Transparent;
            pictureBox18.Parent = MenuPic;
            pictureBox19.BackColor = Color.Transparent;
            pictureBox19.Parent = MenuPic;
            pictureBox20.BackColor = Color.Transparent;
            pictureBox20.Parent = MenuPic;
            pictureBox21.BackColor = Color.Transparent;
            pictureBox21.Parent = MenuPic;
            pictureBox22.BackColor = Color.Transparent;
            pictureBox22.Parent = MenuPic;
            pictureBox23.BackColor = Color.Transparent;
            pictureBox23.Parent = MenuPic;
            pictureBox24.BackColor = Color.Transparent;
            pictureBox24.Parent = MenuPic;

            var pos = this.PointToScreen(ItemValue1.Location);
            pos = MenuPic.PointToClient(pos);
            ItemValue1.Parent = MenuPic;
            ItemValue1.Location = pos;
            ItemValue1.BackColor = Color.Transparent;
            
            pos = this.PointToScreen(ItemValue2.Location);
            pos = MenuPic.PointToClient(pos);
            ItemValue2.Parent = MenuPic;
            ItemValue2.Location = pos;
            ItemValue2.BackColor = Color.Transparent;

            pos = this.PointToScreen(ItemValue3.Location);
            pos = MenuPic.PointToClient(pos);
            ItemValue3.Parent = MenuPic;
            ItemValue3.Location = pos;
            ItemValue3.BackColor = Color.Transparent;

            pos = this.PointToScreen(ItemValue4.Location);
            pos = MenuPic.PointToClient(pos);
            ItemValue4.Parent = MenuPic;
            ItemValue4.Location = pos;
            ItemValue4.BackColor = Color.Transparent;

            pos = this.PointToScreen(ItemName.Location);
            pos = MenuPic.PointToClient(pos);
            ItemName.Parent = MenuPic;
            ItemName.Location = pos;
            ItemName.BackColor = Color.Transparent;

            pos = this.PointToScreen(label1.Location);
            pos = MenuPic.PointToClient(pos);
            label1.Parent = MenuPic;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            updateMembers();
        }

        private void updateMembers()
        {
            if (_GameScreen.game.player.charInventory.getItem(0) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(0).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(0) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox0.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox0.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox0.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(0) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox0.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox0.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox0.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox0.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox0.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else 
                pictureBox0.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(1) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(1).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(1) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox1.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox1.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox1.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(1) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox1.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox1.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox1.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox1.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox1.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox1.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(2) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(2).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(2) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox2.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox2.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox2.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(2) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox2.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox2.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox2.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox2.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox2.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox2.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(3) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(3).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(3) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox3.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox3.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox3.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(3) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox3.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox3.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox3.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox3.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox3.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox3.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(4) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(4).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(4) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox4.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox4.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox4.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(4) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox4.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox4.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox4.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox4.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox4.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox4.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(5) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(5).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(5) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox5.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox5.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox5.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(5) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox5.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox5.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox5.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox5.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox5.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox5.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(6) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(6).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(6) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox6.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox6.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox6.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(6) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox6.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox6.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox6.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox6.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox6.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox6.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(7) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(7).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(7) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox7.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox7.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox7.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(7) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox7.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox7.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox7.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox7.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox7.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox7.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(8) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(8).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(8) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox8.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox8.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox8.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(8) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox8.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox8.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox8.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox8.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox8.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox8.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(9) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(9).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(9) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox9.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox9.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox9.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(9) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox9.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox9.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox9.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox9.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox9.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox9.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(10) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(10).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(10) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox10.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox10.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox10.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(10) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox10.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox10.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox10.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox10.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox10.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox10.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(11) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(11).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(11) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox11.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox11.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox11.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(11) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox11.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox11.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox11.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox11.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox11.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox11.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(12) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(12).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(12) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox12.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox12.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox12.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(12) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox12.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox12.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox12.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox12.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox12.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox12.Image = Properties.Resources.Empty;

            if (_GameScreen.game.player.charInventory.getItem(13) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(13).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(13) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox13.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox13.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox13.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(13) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox13.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox13.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox13.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox13.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox13.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox13.Image = Properties.Resources.Empty;

            if (_GameScreen.game.player.charInventory.getItem(14) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(14).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(14) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox14.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox14.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox14.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(14) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox14.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox14.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox14.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox14.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox14.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox14.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(15) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(15).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(15) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox15.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox15.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox15.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(15) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox15.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox15.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox15.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox15.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox15.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox15.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(16) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(16).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(16) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox16.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox16.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox16.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(16) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox16.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox16.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox16.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox16.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox16.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox16.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(17) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(17).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(17) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox17.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox17.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox17.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(17) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox17.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox17.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox17.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox17.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox17.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox17.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(18) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(18).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(18) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox18.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox18.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox18.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(18) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox18.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox18.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox18.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox18.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox18.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox18.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(19) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(19).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(19) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox19.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox19.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox19.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(19) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox19.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox19.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox19.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox19.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox19.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox19.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(20) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(20).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(20) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox20.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox20.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox20.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(20) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox20.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox20.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox20.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox20.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox20.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox20.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(21) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(21).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(21) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox21.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox21.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox21.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(21) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox21.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox21.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox21.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox21.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox21.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox21.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(22) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(22).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(22) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox22.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox22.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox22.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(22) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox22.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox22.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox22.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox22.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox22.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox22.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(23) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(23).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(23) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox23.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox23.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox23.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(23) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox23.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox23.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox23.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox23.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox23.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox23.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(24) != null)
            {
                switch (_GameScreen.game.player.charInventory.getItem(24).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon weapon = _GameScreen.game.player.charInventory.getItem(24) as Weapon;
                        switch (weapon.WeaponRange)
                        {
                            case Weapon.DamageRangeTypes.Narrow:
                                pictureBox24.Image = Properties.Resources.Weapon_Narrow;
                                break;
                            case Weapon.DamageRangeTypes.Average:
                                pictureBox24.Image = Properties.Resources.Weapon_Avg;
                                break;
                            case Weapon.DamageRangeTypes.Wide:
                                pictureBox24.Image = Properties.Resources.Weapon_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(24) as Armor;
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                pictureBox24.Image = Properties.Resources.Armor_Light;
                                break;
                            case Item.StatTypes.Balanced:
                                pictureBox24.Image = Properties.Resources.Armor_Med;
                                break;
                            case Item.StatTypes.Heavy:
                                pictureBox24.Image = Properties.Resources.Armor_Heavy;
                                break;
                        }
                        break;
                    case Items.Item.Types.POTION:
                        pictureBox24.Image = Properties.Resources.Potion;
                        break;
                    case Items.Item.Types.RELIC:
                        pictureBox24.Image = Properties.Resources.Relics;
                        break;
                }
            }
            else
                pictureBox24.Image = Properties.Resources.Empty;
            if (_GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot) == null)
            {
                ItemName.Text = " N / A";
                ItemValue1.Visible = false;
                ItemValue2.Visible = false;
                ItemValue3.Visible = false;
                ItemValue4.Visible = false;

            }
            else
            {
                ItemName.Text = _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot).Name;
                switch (_GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot).Type)
                {
                    case Items.Item.Types.WEAPON:
                        Weapon wep = _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot) as Weapon;
                        ItemValue1.Text = "Damage: " + wep.lowDamage + " - " + (wep.lowDamage + wep.damageRange);
                        ItemValue2.Text = "Atk Speed: ";
                        switch(wep.Speed)
                        {
                            case 2:
                                ItemValue2.Text +="Slow";
                                break;
                            case 4:
                                ItemValue2.Text +="Average";
                                break;
                            case 6:
                                ItemValue2.Text +="Fast";
                                break;
                        }
                        ItemValue1.Visible = true;
                        ItemValue2.Visible = true;
                        break;
                    case Item.Types.ARMOR:
                        Armor armor = _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot) as Armor;
                        ItemValue1.Text = "Armor: " + armor.effectiveValue();
                        ItemValue2.Text = "MovementSpeed: ";
                        switch (armor.ArmorType)
                        {
                            case Item.StatTypes.Light:
                                ItemValue2.Text += "1.4x";
                                break;
                            case Item.StatTypes.Balanced:
                                ItemValue2.Text += "1x";
                                break;
                            case Item.StatTypes.Heavy:
                                ItemValue2.Text += ".8";
                                break;
                        }
                        ItemValue1.Visible = true;
                        ItemValue2.Visible = true;
                        break;
                    case Item.Types.RELIC:
                        Relic relic = _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot) as Relic;
                        ItemValue1.Text = "Type: " + relic.relicType;
                        ItemValue2.Text = "Multiplier: " + relic.effectiveValue();
                        ItemValue1.Visible = true;
                        ItemValue2.Visible = true;
                        break;
                    case Item.Types.POTION:
                        ItemValue1.Text = "Heals: " + _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot).effectiveValue();
                        ItemValue1.Visible = true;
                        ItemValue2.Visible = false;
                        break;
                }
                        
                
            }
        }

        private void pictureBox0_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 0;
            updateMembers();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 1;
            updateMembers();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 2;
            updateMembers();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 3;
            updateMembers();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 4;
            updateMembers();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 5;
            updateMembers();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 6;
            updateMembers();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 7;
            updateMembers();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 8;
            updateMembers();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 9;
            updateMembers();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 10;
            updateMembers();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 11;
            updateMembers();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 12;
            updateMembers();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 13;
            updateMembers();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 14;
            updateMembers();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 15;
            updateMembers();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 16;
            updateMembers();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 17;
            updateMembers();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 18;
            updateMembers();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 19;
            updateMembers();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 20;
            updateMembers();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 21;
            updateMembers();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 22;
            updateMembers();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 23;
            updateMembers();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.selectedSlot = 24;
            updateMembers();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            _GameScreen.Show();
            _GameScreen.FrameCounter.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot) != null)
            {
                foreach (int i in _GameScreen.game.player.charInventory.equippedSlot)
                {
                    if (_GameScreen.game.player.charInventory.selectedSlot == i)
                    {
                        _GameScreen.game.player.charInventory.unEquip(i);
                        label1.Text = "You Have un-Equipped: " + _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot).Name;
                        label1.Visible = true;
                        return;
                    }
                }
                _GameScreen.game.player.charInventory.EquipItem(_GameScreen.game.player.charInventory.selectedSlot);
                label1.Text = "You Have Equipped: " + _GameScreen.game.player.charInventory.getItem(_GameScreen.game.player.charInventory.selectedSlot).Name;
                label1.Visible = true;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.DeleteItem(_GameScreen.game.player.charInventory.selectedSlot);
            updateMembers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _GameScreen.game.player.charInventory.AddRandomItem(_GameScreen.game.player.Level, _GameScreen.game._PlayThroughNum);
            updateMembers();
        }


    }
}
