using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitByBit.Entities;

namespace BitByBit.Items
{
    public class Relic : EquipableItem
    {
        public BaseCharacter.StatTypes relicType;
        public Relic(Random r, int playerLevel)
            : base(r, playerLevel, Inventory.Rarities.RARE)
        {   
            Type = Item.Types.RELIC; 
            relicType = (BaseCharacter.StatTypes)SeededGen.Next(4);
            Name = "Lvl " + playerLevel + " Relic";
        }
        /// <summary>
        /// Returns an additive percentage;
        /// </summary>
        /// <returns></returns>
        public override int effectiveValue()
        {
            return 15 + Level;
        }
    }
}
