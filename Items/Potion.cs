using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Items
{
    class Potion : Item
    {
        public int AmountInStack { set; get; }
        public const int MaxStack = 10;
        public static bool PotExists;
        public Potion(Random r)
            : base(r, 1, Inventory.Rarities.COMMON)
        {
            Type = Types.POTION;
            Name = "" + Type;
            AmountInStack++;
            PotExists = true;
        }
        public override int effectiveValue()
        {
            AmountInStack--;
            return 50;
        }
    }
}
