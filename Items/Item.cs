using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Items
{
	/// <summary>
	/// Base class for Items
    /// 
    /// </summary>
	public abstract class Item
	{
        protected static Random SeededGen;
        public int Level { private set; get; }
        protected double TotalStatValue { set; get; }
        public Inventory.Rarities Rarity { protected set; get; }
        public Types Type { protected set; get; }
        public double MoneyValue { protected set; get; }
        public string Name { protected set; get; }

        public enum StatTypes
        {
            Light,
            Balanced,
            Heavy
        }

        public enum Types
        {
            WEAPON,
            ARMOR,
            RELIC,
            POTION,
        }
        
        public Item(Random rand, int playerLevel, Inventory.Rarities rarity)
        {
            SeededGen = rand;
            Level = playerLevel;
            Rarity = rarity;
            MoneyValue = playerLevel * 2;
            Name = "Level " + Level + " " + Type;
        }
        /// <summary>
        /// Returns the effective value of the item
        /// </summary>
        /// <returns></returns>
        public abstract int effectiveValue();

        public override string ToString()
        {
            String str = "The item's name is " + Name + " and it is level " + Level;
            str += "\nIt is a " + Rarity + " Item.";
            str += "\nIt is a " + Type;
            str += "\nThe total stat value is " + TotalStatValue;
            str += "\nIt is worth " + MoneyValue +"\n";
            return str;
        }
    }
}
