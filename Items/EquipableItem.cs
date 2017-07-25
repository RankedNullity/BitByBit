using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Items
{
    public abstract class EquipableItem : Item
    {
        public EquipableItem(Random rand, int playerLevel, Inventory.Rarities rare)
            : base(rand, playerLevel, rare)
        {
            Name = "";
            double statValue = (Level + 1) * Inventory.PureRandomScalar(5, 75);
            Inventory.Rarities tempRarity = Rarity;
            statValue *= Inventory.RarityModifier(tempRarity);
            Rarity = tempRarity;
            TotalStatValue = Math.Round(statValue, 1, MidpointRounding.AwayFromZero);
            statValue *= Inventory.RandomScalar(SeededGen, 3, .66);
            MoneyValue = Math.Round(statValue, 0, MidpointRounding.AwayFromZero);
        }
    }
}
