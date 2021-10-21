using Items.Interface;
using Items.GeneralItem;

namespace Items
{
    public class Conjured : Normal
    {
        public Conjured(Item item): base(item)
        {

        }

        public override void UpdateQuality()
        {
            --_item.SellIn;

            if (_item.SellIn > 0) 
                --_item.Quality;

            else
                _item.Quality -= 2;
        }
    }
}