namespace GildedRoseKata;

public class AgedBriedStrategy(Item item) : ItemStrategy(item)
{
    public static string Name = "Aged Brie";
    public override void HandleExpired()
    {
        IncrementQualityIfUnderMax();
    }

    public override void HandleQuality()
    {
        IncrementQualityIfUnderMax();
    }
}