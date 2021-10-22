using Items.Interface;
using Items.GeneralItem;
using Items;

namespace Items
{
    public class Conjured : Normal
    {
        public Conjured(Item item): base(item) { }

        public override void UpdateQuality()
        {
            --item.SellIn;

            if (item.SellIn > 0) 
                --item.Quality;

            else
                item.Quality -= 2;
        }
    }
}