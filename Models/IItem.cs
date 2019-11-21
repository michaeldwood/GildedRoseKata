namespace GildedRose.Models
{
    public interface IItem
    {
        string Name { get; set; }
        int Quality { get; set; }
        int SellIn { get; set; }

        string ToString();

        int DegradationMultiplyer();
    }
}