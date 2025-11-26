using GildedRoseKata;

namespace GildedRoseTests;

public class CompleteItemBuilder()
{
    private string _name = "pants";
    private int _sellIn = 15;
    private int _quality = 20;

    public CompleteItemBuilder WithMinQuality()
    {
        return WithQuality(0);
    }
    
    public CompleteItemBuilder WithMaxQuality()
    {
        return WithQuality(50);
    }
    
    public CompleteItemBuilder AsBackstagePass()
    {
        return WithName("Backstage passes to a TAFKAL80ETC concert");
    }
    
    public CompleteItemBuilder AsAgedBrie()
    {
        return WithName("Aged Brie");
    }

    public CompleteItemBuilder AsSulfuras()
    {
        return WithName("Sulfuras, Hand of Ragnaros");
    }
    
    public CompleteItemBuilder AsExpired()
    {
        return WithSellIn(0);
    }
    
    public CompleteItemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CompleteItemBuilder WithSellIn(int sellIn)
    { 
        _sellIn = sellIn;
        return this;
    }

    public CompleteItemBuilder WithQuality(int quality)
    {
        _quality = quality;
        return this;
    }
    
    public Item Build()
    {
        return new Item { Name = _name, SellIn = _sellIn, Quality = _quality };
    }
}