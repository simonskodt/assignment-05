using System.Collections.Generic;
using Items;
using Items.GeneralItem;
using Items.Interface;
using System.Linq;

namespace Items.Factory
{
    public class ItemFactory 
    {
        public static Dictionary<string, IItem> allItems = new Dictionary<string, IItem>();
        
        #region Names
        public const string AGED_BRIE = "Aged Brie";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        public const string CONJURED = "Conjured Mana Cake";
        #endregion

        public ItemFactory(Item item) 
        {
            allItems.Add(AGED_BRIE, new Brie(item));
            allItems.Add(SULFURAS, new Sulfuras());
            allItems.Add(BACKSTAGE, new Backstage(item));
            allItems.Add(CONJURED, new Conjured(item));
        }

        

        public IItem HandleItem(Item item) 
        {
            if (IsNormalItem(item)) return new Normal(item);
            return (IItem) allItems.Select(v => v.Value.Equals(item.Name));
        }

        bool IsNormalItem(Item item) 
        {
            return !allItems.Any(v => v.Value.Equals(item.Name));
        }
    }
}