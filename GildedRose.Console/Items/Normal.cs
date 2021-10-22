using Items.Interface;
using Items.GeneralItem;

namespace Items
{
    public class Normal : IItem
    {
        protected Item item;

        public Normal(Item item)
        {
            this.item = item;
        }

        public virtual void UpdateQuality() 
        {
            --item.SellIn;

            if (item.SellIn >= 0) --item.Quality;

            else item.Quality -= 2;
        }
    }
}