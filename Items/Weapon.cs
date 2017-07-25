using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Items
{
    public class Weapon : EquipableItem
    {
        public int Speed { private set; get; }
        private StatTypes weaponType;
        public DamageRangeTypes WeaponRange;
        private double damageValue;
        public int lowDamage, damageRange;
        public const int LowestSpeed = 1;

	    public enum DamageRangeTypes
	    {
			Narrow,
			Average,
			Wide
		}

        public Weapon(Random rand, int playerLevel, Inventory.Rarities rare)
            : base(rand, playerLevel, rare)
        {
            Type = Item.Types.WEAPON;
            if (Rarity != Inventory.Rarities.UNIQUE)
            {
                RandomizeStats();
                NameModifier();
            }
            else
            {
                GenerateUnique();
            }
        }
        /// <summary>
        /// Returns an int that is the actual damage done by weapon
        /// </summary>
        /// <returns></returns>
        public override int effectiveValue()
        {
            return SeededGen.Next(lowDamage, lowDamage + damageRange);
        }

    	private void RandomizeStats()
		{
            weaponType = (Item.StatTypes)SeededGen.Next(0, 3);
			WeaponRange = (DamageRangeTypes)SeededGen.Next(0,3);
            ApplyWeaponTypeStats();
            ApplyRangeTypeStats();
		}

        private void ApplyWeaponTypeStats()
        {
            double topDmg, botDmg;
            switch (weaponType)
            {
                case Item.StatTypes.Light:
                    Speed = 6;
                    topDmg = .45;
                    botDmg = .81;
                    Name += Item.StatTypes.Light;
                    break;
                case Item.StatTypes.Balanced:
                    Speed = 4;
                    topDmg = .75;
                    botDmg = .866;
                    Name += Item.StatTypes.Balanced;
                    break;
                case Item.StatTypes.Heavy:
                    Speed = 2;
                    topDmg = 1;
                    botDmg = .8888;
                    Name += Item.StatTypes.Heavy;
                    break;
                default:
                    Console.WriteLine("ApplyWeaponStats has broken here");
                    Speed = 2;
                    topDmg = 1;
                    botDmg = .5;
                    break;
            }
            damageValue = TotalStatValue * Inventory.RandomScalar(SeededGen, topDmg, botDmg);
        }

        private void ApplyRangeTypeStats()
        {
            double LowDamage = damageValue;
            double DamageRange = damageValue;
            switch (WeaponRange)
            {
                /* Formula for Ranges:
                 * LowDamage = value;
                 * damage Range = (.5 - value) * 2;
                 */
                case DamageRangeTypes.Narrow:
                    LowDamage *= Inventory.RandomScalar(SeededGen, .45, .777);
                    DamageRange *= (.5 - (LowDamage/damageValue)) * 2;
                    Name += " Daggers";
                    break;
                case DamageRangeTypes.Average:
                    LowDamage *= Inventory.RandomScalar(SeededGen,.35, .714);
                    DamageRange *= (.5 - (LowDamage / damageValue)) * 2;
                    Name += " Spear";
                    break;
                case DamageRangeTypes.Wide:
                    LowDamage *= Inventory.RandomScalar(SeededGen,.25, .6);
                    DamageRange *= (.5 - (LowDamage / damageValue)) * 2;
                    Name += " Claymore";
                    break;
                default:
                    Console.WriteLine("ApplyRangeType has broken here");
                    WeaponRange = (DamageRangeTypes)SeededGen.Next(0, 2);
                    break;
            }
            this.lowDamage = Convert.ToInt32(LowDamage);
            this.damageRange = Convert.ToInt32(DamageRange);
        }

        private void NameModifier()
        {
            int prefixExists = SeededGen.Next(2), suffixExists = SeededGen.Next(2);
            if (prefixExists == 1)
            {
                switch (Rarity)
                {
                    case Inventory.Rarities.EPIC:
                        Name = Inventory.NameRandomizer(SeededGen,"Champion", "Unstoppable", "Infallible", "Super Elite", "Ultimate", "Polished", "Grandmaster's", "Genocidal", "Really Really Above Average") + " " + Name;
                        break;
                    case Inventory.Rarities.RARE:
                        Name = Inventory.NameRandomizer(SeededGen,"Superior", "Elite", "Amazing", "Sharp", "Deadly", "Knight's", "Battle-worn", "Better", "Above Average") + " " + Name;
                        break;
                    case Inventory.Rarities.UNCOMMON:
                        Name = Inventory.NameRandomizer(SeededGen,"Mediocre", "Decent", "Average", "So-So", "Unimpressive", "Old", "Okay", "Unexceptional", "Normal", "Acceptable") + " " + Name;
                        break;
                    case Inventory.Rarities.COMMON:
                        Name = Inventory.NameRandomizer(SeededGen,"Dumb", "Bad", "Dull", "Crappy", "Lackluster", "Simple", "Sketchy", "Shabby", "Cheap", "Rusty", "Peasant's", "Below Average") + " " + Name;
                        break;
                }
            }
            if (suffixExists == 1)
            {
                switch (Rarity)
                {
                        //CHANGETHIS Add Suffixes
                    case Inventory.Rarities.EPIC:
                        Name += " " + Inventory.NameRandomizer(SeededGen,"of Doom");
                        break;
                    case Inventory.Rarities.RARE:
                        Name += " " + Inventory.NameRandomizer(SeededGen,"of Death");
                        break;
                    case Inventory.Rarities.UNCOMMON:
                        Name += " " + Inventory.NameRandomizer(SeededGen,"of Pain");
                        break;
                    case Inventory.Rarities.COMMON:
                        Name += " " + Inventory.NameRandomizer(SeededGen,"of Pricks");
                        break;
                }
            }
	    }

        private void GenerateUnique()
    	{
        	int random = SeededGen.Next(1 , 3);
            int TotalStatValue = (int)this.TotalStatValue;
        	switch(random)
        	{
        		case 1:
        			UniqueValueSetter("Super Heavy DoomHammer of Doom", "Doesn't have windfury but the damage...", 50, TotalStatValue ,  TotalStatValue * 3);
        			break;
        		case 2:
        			UniqueValueSetter("Really Really REALLY Fast Needle (Really Fast)", "Like a swarm of hornets...", 5000, TotalStatValue / 5 , 0);
        			break;
        		case 3:
        			UniqueValueSetter("Jelly Flopp Hammer Popsickle?", "Communism Maybe?..." , 100,  0, TotalStatValue * 6);
        			break;
                
                    /*This is broken; Fix this when Trivia is instantiated*/ 
        	}
    	}
        private void UniqueValueSetter(string Name, string description, int Speed, int LowDamage, int DamageRange)
    	{
        	this.Name = Name;
        	this.Speed = Speed; 
        	this.lowDamage = LowDamage;
        	this.damageRange = DamageRange;
    	}
        public override string ToString()
        {
            String str = base.ToString();
            str += "The speed is " + Speed;
            str += "\nThe LowDamage is " + lowDamage;
            str += "\nThe DamageRange is " + damageRange;
            return str;
        }
    }
}	