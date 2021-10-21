using Items.Interface;
using Items.GeneralItem;

namespace Items
{
    public class Normal : IItem
    {
        Item _item;

        public Normal(Item item)
        {
            _item = item;
        }

        public virtual void UpdateQuality() 
        {
            --_item.SellIn;

            if (_item.SellIn > 0) _item.Quality -= 2;

            else _item.Quality -= 4;
        }

        
    }
}