using BitByBit.Items;
using System;
using BitByBit.Entities;

namespace BitByBit
{
    public sealed class Inventory
    {
        //inventory[0] will always be null
        private int maxSpace;
        public int MoneyAmount { set; get; }
        private Item[] inventory;
        public int[] equippedSlot;
        public static int[] RarityValue = new int[5] { 0, 1, 3, 5, 8 };
        private static Random seededGen;
        public int selectedSlot;

        public enum Rarities
        {
            UNIQUE,
            EPIC,
            RARE,
            UNCOMMON,
            COMMON
        }
        /// <summary>
        /// Returns the first FreeSpace in Inventory
        /// </summary>
        public int FirstFreeSpace
        { 
            get
            {
                int i = 0;
                while (i < maxSpace)
                {
                    if (inventory[i] != null)
                        i++;
                    else
                        break;
                }
                return i;
            }

        }

        public Weapon.DamageRangeTypes weaponType
        {
            get
            {
                if (equippedSlot[(int)Item.Types.WEAPON] != maxSpace)
                {
                    Weapon weapon = inventory[equippedSlot[(int)Item.Types.WEAPON]] as Weapon;
                    return weapon.WeaponRange;
                }
                return Weapon.DamageRangeTypes.Narrow;
            }
        }

        public Item.StatTypes armorType
        {
            get
            {
                if (equippedSlot[(int)Item.Types.ARMOR] != maxSpace)
                {
                    Armor armor = inventory[equippedSlot[(int)Item.Types.ARMOR]] as Armor;
                    return armor.ArmorType;
                }
                return Item.StatTypes.Light;
            }
        }

        public double RelicModifier
        {
            get
            {
                int mod = 1;
                if (equippedSlot[(int)Item.Types.RELIC] != maxSpace)
                    return mod + inventory[equippedSlot[(int)Item.Types.RELIC]].effectiveValue() / 100.0;
                return mod;
            }
        }
        public BaseCharacter.StatTypes ModifyStat
        {
            get
            {
                if(equippedSlot[(int)Item.Types.RELIC] != maxSpace)
                {
                    var relic = inventory[equippedSlot[(int)Item.Types.RELIC]] as Relic;
                    return relic.relicType;
                }
                return BaseCharacter.StatTypes.MaxHealth;
            }
        }
        /// <summary>
        /// Returns the value of Attack Speed of the Weapon Used
        /// Measured in Frame Delay
        /// </summary>
        public int AtkSpeed
        {
            get
            {
                if (equippedSlot[(int)Item.Types.WEAPON] != maxSpace)
                {
                    Weapon Wep = inventory[equippedSlot[(int)Item.Types.WEAPON]] as Weapon;
                    return 6300 / (int)Wep.Speed;
                }
                return 7000;
            }
        }
        public double MoveSpeedMod
        {
            get
            {
                if(equippedSlot[(int)Item.Types.ARMOR] != maxSpace)
                {
                    Armor armor = inventory[equippedSlot[(int)Item.Types.ARMOR]] as Armor;
                    return armor.SpeedModifier; 
                }
                return 1;
            }
        }

        private int _firstFreePotionSlot
        {
            get
            {
                int i = 0;
                while (i < maxSpace)
                {
                    if(inventory[i] is Potion)
                        return i;
                    i++;
                }
                return i;
            }
        }
        
        /// <summary>
        /// Creates an Inventory of length maxSpace + 1 
        /// Inventory[0] will always remain null;
        /// </summary>
        /// <param name="maxSpace"></param>
        public Inventory(int maxSpace, Random r)
        {
            this.maxSpace = maxSpace;
            inventory = new Item[maxSpace];
            equippedSlot = new int[3]{maxSpace,maxSpace,maxSpace};
            seededGen = r;
            MoneyAmount = 100;
        }

        /// <summary>
        /// Adds Item t into the first available space in inventory
        /// If successful, returns success message with name
        /// Otherwise, returns Inventory is Full!
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public string AddItem(Item t)
        {
            if (FirstFreeSpace != maxSpace)
            {
                inventory[FirstFreeSpace] = t;
                return "You have picked up a(n) " + t.Name;
            }
            else
            {
                return "Inventory is full! Could not pick up item";
            }
        }

        public int useEquipped(Item.Types Type)
        {
            if (Type == Item.Types.POTION && _firstFreePotionSlot != maxSpace)
            {
                int i = inventory[_firstFreePotionSlot].effectiveValue();
                inventory[_firstFreePotionSlot] = null;
                return i;
            }
            else if (_firstFreePotionSlot == maxSpace)
                return 0;
            else if (equippedSlot[(int)Type] != maxSpace)
                return inventory[equippedSlot[(int)Type]].effectiveValue();
            return 0;
        }

        /// <summary>
        /// Equips the item at index slot
        /// </summary>
        /// <param name="i"></param>
        public void EquipItem(int slot)
        {
            if (inventory[slot].Type == Item.Types.POTION)
                return;
            equippedSlot[(int)inventory[slot].Type] = slot;    
           
        }
        public void unEquip(int slot)
        {
            if (inventory[slot] == null)
                return;
            if (inventory[slot].Type == Item.Types.POTION)
                return;
            equippedSlot[(int)inventory[slot].Type] = maxSpace;
        }
        /// <summary>
        /// Exchanges the item in slot1 with the item in slot2
        /// </summary>
        /// <param name="slot1"></param>
        /// <param name="slot2"></param>
        public void MoveItem(int slot1, int slot2)
        {
            var temp = inventory[slot1];
            inventory[slot1] = inventory[slot2];
            inventory[slot2] = temp;
        }
        /// <summary>
        /// Deletes the item in the specified index
        /// </summary>
        /// <param name="slot"></param>
        public void DeleteItem(int slot)
        {
            inventory[slot] = null;
        }
        
        public Item getItem(int slot)
        {
            return inventory[slot];
        }

        public string AddRandomItem(int playerLevel, int playThroughNum, int RarityAsNumber)
        {
            if (FirstFreeSpace == maxSpace)
                return "Inventory is full, couldn't pick up";
            double tempRare = RarityAsNumber;
            for(int i = 0; i < playThroughNum; i+= 2)
                tempRare *= 1.2;
            RarityAsNumber = (int)tempRare;
            Rarities tempRarity = GetRarity(RarityAsNumber);
            int[] chanceOf = new int[4]{ 25 , 25 , 0 , 0 };
            switch(tempRarity)
            {
                case Rarities.COMMON:
                    chanceOf[(int)Item.Types.POTION] = 25 + playThroughNum * 5;
                    break;
                case Rarities.UNCOMMON:
                    chanceOf[(int)Item.Types.POTION] = 25 + playThroughNum * 5 / 2;
                    break;
                case Rarities.RARE:
                    chanceOf[(int)Item.Types.RELIC] = 150 / (playThroughNum / 3 + 1);
                    break;
                case Rarities.EPIC:
                    chanceOf[(int)Item.Types.RELIC] = 50 / (playThroughNum / 3 + 1);
                    break;
                default:
                    chanceOf[(int)Item.Types.ARMOR] = 0;
                    break;
            }

            int total = 0, typeValue, usedSlot = FirstFreeSpace;
            for(int i = 0; i < chanceOf.Length; i++)
                total += chanceOf[i];
            typeValue = seededGen.Next(total);
            switch(checkProb(chanceOf, typeValue))
            {
                case 1:
                    inventory[usedSlot] = new Weapon(seededGen, playerLevel, tempRarity);
                    break;
                case 2:
                    inventory[usedSlot] = new Armor(seededGen, playerLevel, tempRarity);
                    break;
                case 3:
                    inventory[usedSlot] = new Relic(seededGen, playerLevel);
                    break;
                default:
                    /*if(_firstFreePotionSlot == maxSpace)
                    {
                        inventory[usedSlot] = new Potion(seededGen);
                        break;
                    }*/
                    /*Potion potion = inventory[_firstFreePotionSlot] as Potion;
                    potion.AmountInStack++;
                    usedSlot = _firstFreePotionSlot;*/
                    inventory[usedSlot] = new Potion(seededGen);
                    break;
            }
            return "Picked up " + inventory[usedSlot].Name;
        }


        /// <summary>
        /// Takes an array and treats each number as a percentage
        /// Then returns the index when number is less than probability
        /// </summary>
        private static int checkProb(int[] probability, int number, int index)
        {
            if (number < probability[index])
                return index;
            return checkProb(probability, number - probability[index], index + 1);
        }
        private static int checkProb(int[] probability, int number)
        {
            return checkProb(probability, number, 0);
        }

        public string AddRandomItem(int playerLevel, int playThroughNum)
        {
            return AddRandomItem(playerLevel, playThroughNum, seededGen.Next(100));
        }


        public static string NameRandomizer(Random r, params string[] array)
        {
            int j = r.Next(0, array.Length);
            return array[j];
        }

        
        /// <summary>
        /// Generates an item with Random r, scaled to playerLevel,
        /// and with Rarity based on RarityAsNumber
        /// Reworked Drop System 3-23-15
        /// </summary>
        /// <param name="r"></param>
        /// <param name="playerLevel"></param>
        /// <param name="RarityAsNumber"></param>
        /// <returns></returns>
        public static Rarities GetRarity(int RarityAsNumber, int index)
        {
            if (index == 0)
            {
                return Rarities.UNIQUE;
            }
            else if (RarityAsNumber > Math.Pow(RarityValue[index], 2))
            {
                return GetRarity(RarityAsNumber - (int)Math.Pow(RarityValue[index], 2), index - 1);
            }
            return (Rarities)index;

        }

        public static Rarities GetRarity(int RarityAsNumber)
        {
            return GetRarity(RarityAsNumber, 4);
        }

        public static double RarityModifier(Rarities Rarity)
        {
            if (Rarity == Rarities.COMMON)
            {
                return 1;
            }
            return 1.2 * RarityModifier((Rarities)((int)(Rarity) + 1));
        }
        //Added 3-20-15 
        public static double RandomScalar(Random r, double maxScale, double minPercent)
        {
            while (minPercent > 1)
            {
                minPercent /= 10;
            }
            double t = (((maxScale * minPercent) + maxScale * (1 - minPercent) * (r.NextDouble())));

            return t;
        }

        //Added 3-20-15
        public static double PureRandomScalar(double maxScale, double minPercent)
        {
            var r = new Random();
            return RandomScalar(r, maxScale, minPercent);
        }
    }
    
}
