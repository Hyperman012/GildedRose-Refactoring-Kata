using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            CreateStrategy(item).ProcessItem();
        }
    }

    private ItemStrategy CreateStrategy(Item item)
    {
        if (item.Name == BackstagePassStrategy.Name) return new BackstagePassStrategy(item);
        if (item.Name == AgedBriedStrategy.Name) return new AgedBriedStrategy(item);
        if (item.Name == SulfurasItemStrategy.Name) return new SulfurasItemStrategy(item);
        return new ItemStrategy(item);
    }
}