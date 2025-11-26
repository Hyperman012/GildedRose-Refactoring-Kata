using GildedRoseKata;

namespace GildedRoseTests;

public class ItemBuilder()
{
    private string _name = "pants";
    private int _sellIn = 15;
    private int _quality = 20;

    public ItemBuilder WithMinQuality()
    {
        return WithQuality(0);
    }
    
    public ItemBuilder WithMaxQuality()
    {
        return WithQuality(50);
    }
    
    public ItemBuilder AsBackstagePass()
    {
        return WithName("Backstage passes to a TAFKAL80ETC concert");
    }
    
    public ItemBuilder AsAgedBrie()
    {
        return WithName("Aged Brie");
    }

    public ItemBuilder AsSulfuras()
    {
        return WithName("Sulfuras, Hand of Ragnaros");
    }
    
    public ItemBuilder AsExpired()
    {
        return WithSellIn(0);
    }
    
    public ItemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ItemBuilder WithSellIn(int sellIn)
    { 
        _sellIn = sellIn;
        return this;
    }

    public ItemBuilder WithQuality(int quality)
    {
        _quality = quality;
        return this;
    }
    
    public Item Build()
    {
        return new Item { Name = _name, SellIn = _sellIn, Quality = _quality };
    }
}