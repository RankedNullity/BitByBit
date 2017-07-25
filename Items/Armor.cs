using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Items
{
    class Armor : EquipableItem
    {
        public StatTypes ArmorType;
        public double SpeedModifier { private set; get; }
        private int armorValue;
        private const double armorScale = 2, levelScale = 1.35;

        public Armor(Random rand, int playerlevel, Inventory.Rarities rare)
            : base(rand, playerlevel, rare)
        {
            Type = Item.Types.ARMOR;
            ArmorType = (StatTypes)SeededGen.Next(3);
            double spd, armor;
            switch (ArmorType)
            {
                case StatTypes.Balanced:
                    armor = armorScale * 1.25 * Math.Pow(levelScale, playerlevel);
                    spd = 1;
                    Name = "Leather";
                    break;
                case StatTypes.Heavy:
                    armor = armorScale * 1.5 * Math.Pow(levelScale, playerlevel);
                    spd = .8;
                    Name = "Chainmail";
                    break;
                default:
                    armor = armorScale * 1 * Math.Pow(levelScale, playerlevel);
                    spd = 1.4;
                    Name = "Gel";
                    break;
            }
            SpeedModifier = spd;
            armorValue = (int)armor;
            Name += " Armor";
        }

        public override int effectiveValue()
        {
            return armorValue;
        }   
    }
}
