using Items.GeneralItem;
using Items.Interface;

namespace Items.Factory
{
    public class ItemFactory 
    {
        public ItemFactory(Item item) 
        {
            HandleItem(item);
        }

        // Responsible for delegating out the handlers of the given item.
        public IItem HandleItem(Item item) 
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new Brie(item);

                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(); 

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Backstage(item);

                case "Conjured Mana Cake":
                    return new Conjured(item);

                // This applies for:
                //     "Elixir of the Mongoose" and
                //     "Conjured Mana Cake" (inherits from Normal.cs)
                default:
                    return new Normal(item);
            }
        }
    }
}