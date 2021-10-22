using Items.Interface;

namespace Items.GeneralItem
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        // Not in use
        public override string ToString() 
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }    
    }
}