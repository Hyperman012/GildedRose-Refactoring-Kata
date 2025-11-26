namespace GildedRoseKata;

public class BackstagePassStrategy(Item item) : ItemStrategy(item)
{
    public static string Name = "Backstage passes to a TAFKAL80ETC concert";
    public override void HandleExpired()
    {
        item.Quality = 0;
    }

    public override void HandleQuality()
    {
        IncrementQualityIfUnderMax();
        if (item.SellIn < 11)
        {
            IncrementQualityIfUnderMax();
        }

        if (item.SellIn < 6)
        {
            IncrementQualityIfUnderMax();
        }
    }
}