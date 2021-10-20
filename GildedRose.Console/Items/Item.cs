namespace Items.Item
{
    public class Item
    {
        protected string name;
        protected int sellIn;
        protected int quality;
        
        protected virtual void UpdateQuality() {}
    }
}