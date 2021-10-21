using Items.Interface;
using Items.GeneralItem;

namespace Items
{
    public class Backstage : IItem
    {
        Item _item;

        public Backstage(Item item)
        {
            _item = item;
        }
        
        public void UpdateQuality() 
        {
            --_item.SellIn;

            if (_item.SellIn > 11) ++_item.Quality;

            if (_item.SellIn > 6) _item.Quality += 2;
            
            if (_item.SellIn == 0) _item.Quality = 0;
        }
    }
}