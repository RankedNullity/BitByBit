using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitByBit.Entities
{
    public class ShopKeeper : BaseCharacter
    {
        private const int maxShop = 4;

        public ShopKeeper(Random r, int playerLevel, int playThrough)
            : base(r, playerLevel)
        {
            for (int i = 0; i < maxShop; i++)
            {
                this.charInventory.AddRandomItem(playerLevel, playThrough);
            }
            BaseStat[(int)StatTypes.MaxHealth] = -1;
        }
    }
}
