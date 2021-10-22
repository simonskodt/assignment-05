using Items.GeneralItem;

namespace Items
{
    public class Conjured : Normal
    {
        public Conjured(Item item): base(item) { }

        // This decrementation happens twice as fast as a normal item.
        // This could as well have been done without the virtual dispatching.
        // But it is also to showcase the possibilities within this implementation.
        public override void UpdateQuality()
        {
            --item.SellIn;

            if (item.SellIn > 0) item.Quality -= 2;

            else item.Quality -= 4;
        }
    }
}