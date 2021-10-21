using Items.Interface;
using Items.GeneralItem;

namespace Items
{
    public class Brie : IItem
    {
        Item _item;

        public Brie(Item item) 
        {
            _item = item;
        }
    
        public void UpdateQuality() 
        {
            --_item.SellIn;
            ++_item.Quality;
        }
    }
}