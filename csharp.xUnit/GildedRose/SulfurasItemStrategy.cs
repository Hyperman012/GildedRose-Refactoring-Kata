namespace GildedRoseKata;

public class SulfurasItemStrategy(Item item) : ItemStrategy(item)
{
    public static string Name =  "Sulfuras, Hand of Ragnaros";
    public override void HandleExpired() { }

    public override void UpdateSellIn() { }

    public override void HandleQuality() { }
}