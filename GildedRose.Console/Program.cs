using System;
using System.Collections.Generic;
using Items;
using Items.GeneralItem;
using Items.Interface;
using Items.Factory;


namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        // Composition
        IItem _iItem;
        Normal _normal;
        Brie _brie;
        Sulfuras _sulfuras;
        Backstage _backstage;
        Conjured _conjured;

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                            {
                                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
				                // this conjured item does not work properly yet
                                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                // new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                                // new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                                // new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49}
                            }
            };


            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    System.Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                System.Console.WriteLine("");
                app.UpdateItems();
            }
        }

        public void UpdateItems()
        {
            foreach (Item item in Items)
            {
                GetItems(item).UpdateQuality();
            }
        }

        IItem GetItems(Item item) 
        {
            return new ItemFactory(item).HandleItem(item);
        }
    }
}