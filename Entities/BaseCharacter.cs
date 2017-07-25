using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    public abstract class BaseCharacter : Entity
    {
        public static Random SeededGen;
        public int[] BaseStat = new int[4];
        public int CurrentHealth { protected set; get; }
        public int XP { set; get; }
        public int Level { set; get; }
        public Inventory charInventory;
        protected int XPNeeded
        {
            get
            { return 10 * (int)Math.Pow(1.5, Level); }
        }
        public override int Damage
        {
            get
            {
                return BaseStat[(int)StatTypes.Damage] + this.charInventory.useEquipped(Items.Item.Types.WEAPON);
            }
        }
        public virtual int MaxHealth
        {
            get
            {
                return BaseStat[(int)StatTypes.MaxHealth];
            }
        }

        public enum StatTypes
        {
            MaxHealth,
            Damage,
            Speed,
            AtkSpeed
        }

        public BaseCharacter(Random r, int Level)
        {
            SeededGen = r;
            this.Level = Level;
            BaseStat[(int)StatTypes.MaxHealth] = Level * 20;
            CurrentHealth = BaseStat[(int)StatTypes.MaxHealth];
            charInventory = new Inventory(1, SeededGen);
        }
        /// <summary>
        /// this.Basecharacter does its damage to character
        /// </summary>
        /// <param name="character"></param>
        public void dealDamage(BaseCharacter character)
        {
            if (this.Damage > character.charInventory.useEquipped(Items.Item.Types.ARMOR))
                character.CurrentHealth -= (this.Damage - character.charInventory.useEquipped(Items.Item.Types.ARMOR));
        }
    }
}
