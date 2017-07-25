using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitByBit.Items;

namespace BitByBit.Entities
{
    public class Player : AttackingCharacter
    {
        public int unSpentSkillPoints;
        public bool isWalkingUp, isMoving;
        public double xVelocity, yVelocity;
        private double _tempX, _tempY;
        public Player(Random r)
            : base(r, 1)
        {
            BaseStat[(int)StatTypes.Damage] = 5;
            BaseStat[(int)StatTypes.Speed] = 100;
            hitBox = new CollisionBox((Game.BOUNDARY_LEFT +  Game.BOUNDARY_RIGHT)/2, (Game.BOUNDARY_TOP + Game.BOUNDARY_BOT)/2, 60, 70);
            _tempX = hitBox.x;
            _tempY = hitBox.y;
            charInventory = new Inventory(25, SeededGen);
            charInventory.AddItem(new Potion(SeededGen));
            charInventory.AddItem(new Weapon(SeededGen, 1 , Inventory.Rarities.COMMON));
            charInventory.AddItem(new Armor(SeededGen, 1, Inventory.Rarities.COMMON));
            charInventory.EquipItem(0);
            charInventory.EquipItem(1);
            charInventory.EquipItem(2);
            BaseStat[(int)StatTypes.AtkSpeed] = 100;
        }

        public override int MaxHealth
        {
            get
            {
                if (charInventory.ModifyStat == StatTypes.MaxHealth)
                    return (int)(BaseStat[(int)StatTypes.MaxHealth] * charInventory.RelicModifier);
                return BaseStat[(int)StatTypes.MaxHealth];
            }
        }

        /// <summary>
        /// AttackSpeed of the Player. Value is given in frame delayed
        /// </summary>
        public override int MaxCoolDownFrames
        {
            get
            {
                if (charInventory.ModifyStat == StatTypes.AtkSpeed)
                    return (int)(charInventory.AtkSpeed /( BaseStat[(int)StatTypes.AtkSpeed] * charInventory.RelicModifier));
                return charInventory.AtkSpeed / (BaseStat[(int)StatTypes.AtkSpeed]);
            }
        }
        public void movePlayer(Room.Direction direction)
        {
            switch (direction)
            {
                case Room.Direction.Down:
                    _tempY += _pixelsPerFrame;
                    break;
                case Room.Direction.Left:
                    _tempX -= _pixelsPerFrame * 1.3;
                    break;
                case Room.Direction.Right:
                    _tempX += _pixelsPerFrame * 1.3 ;
                    break;
                case Room.Direction.Up:
                    _tempY -= _pixelsPerFrame;
                    break;
            }
            hitBox.x = (int)_tempX;
            hitBox.y = (int)_tempY;
        }

        public void ResetTemps(int x, int y)
        {
            _tempX = x;
            _tempY = y;
            hitBox.x = x;
            hitBox.y = y;
        }

        /// <summary>
        /// Speed is returned
        /// </summary>
        public double _pixelsPerFrame
        {
            get
            {
                if (charInventory.ModifyStat == StatTypes.Speed)
                    return (BaseStat[(int)StatTypes.Speed] / 7 * charInventory.MoveSpeedMod * charInventory.RelicModifier);
                return (BaseStat[(int)StatTypes.Speed] / 7 * charInventory.MoveSpeedMod);
            }
        }

        public void addXP(int XP)
        {
            this.XP += XP;
            if(this.XP >= XPNeeded)
            {
                Level++;
                XP = 0;
                CurrentHealth = BaseStat[(int)StatTypes.MaxHealth];
                this.unSpentSkillPoints += 7;
                Console.WriteLine("You have Levelup'd");
            }
        }
        public void assignSkillPoint(StatTypes statType)
        {
            if (unSpentSkillPoints > 0)
            {
                if (statType == StatTypes.MaxHealth)
                    BaseStat[(int)statType] += 3;
                else if (statType == StatTypes.Damage)
                    BaseStat[(int)statType]++;
                else
                    BaseStat[(int)statType] += 5;
                unSpentSkillPoints--;
            }
            
        }

        //Checks and uses a health potion if need be
        public string usePotion()
        {
            if (CurrentHealth == BaseStat[(int)StatTypes.MaxHealth])
            {
                return "Health is already Full!";   
            }
            int healAmount = charInventory.useEquipped(Item.Types.POTION);
            int tempHealth = CurrentHealth;
            if (tempHealth + healAmount > BaseStat[(int)StatTypes.MaxHealth])
                CurrentHealth = BaseStat[(int)StatTypes.MaxHealth];
            else
                CurrentHealth += healAmount;
            return "You have healed " + (CurrentHealth - tempHealth) + " health";
        }

        //Takes damage minus the armor value of the player
        public string takeDamage(int damage)
        {
            damage -= charInventory.useEquipped(Item.Types.ARMOR);
            if (damage < 0)
                damage = 0;
            CurrentHealth -= damage;
            return "You took " + damage + " damage!";
        }

    }
}
