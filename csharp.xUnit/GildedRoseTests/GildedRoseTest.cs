using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void UpdateQuality_NormalItem_DoesNotChangeName()
    {
        var item = new ItemBuilder().WithName("foo").Build();
        GildedRose app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal("foo", item.Name); 
    }

    [Fact]
    public void UpdateQuality_NormalItemsWith_DecreaseInQualityBy1()
    {
        var item = new ItemBuilder().WithQuality(20).Build();
        GildedRose app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(19, item.Quality); 
    }

    [Fact]
    public void UpdateQuality_NormalItems_DecreaseInSellInBy1()
    {
        var item = new ItemBuilder().WithSellIn(15).Build();
        GildedRose app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(14, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_ExpiredNormalItem_DecreaseInQualityBy2()
    {
        var item = new ItemBuilder().AsExpired().WithQuality(20).Build();
        GildedRose app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(18, item.Quality);
    }
    
    [Fact]
    public void UpdateQuality_NormalItemWithLT0Quality_QualityStays0()
    {
        var item = new ItemBuilder().AsExpired().WithQuality(0).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(0, item.Quality);
    }
    
    [Fact]
    public void UpdateQuality_AgedBrie_IncreasedQualityBy1()
    {
        var item = new ItemBuilder().AsAgedBrie().WithQuality(20).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ExpiredAgedBrie_IncreasesQualityBy2()
    {
        var item = new ItemBuilder().AsExpired().AsAgedBrie().WithQuality(20).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrieWith50Quality_StaysAt50()
    {
        var item = new ItemBuilder().AsAgedBrie().WithMaxQuality().Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrieAbove50Quality_StaysAtOriginalQuality()
    {
        var expectedQuality = 60;
        var item = new ItemBuilder().AsAgedBrie().WithQuality(expectedQuality).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ExpiredAgedBrieAround50Quality_IncreasesBy2ToMaxOf50()
    {
        var item = new ItemBuilder().AsExpired().AsAgedBrie().WithQuality(48).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(50, item.Quality);
    }
    
    [Fact]
    public void UpdateQuality_ExpiredAgedBrieAbove50Quality_StaysAtOriginalQuality()
    {
        var item = new ItemBuilder().AsExpired().AsAgedBrie().WithQuality(68).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(68, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePass_IncreasesQualityBy1()
    {
        var  item = new ItemBuilder().AsBackstagePass().WithQuality(20).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePassLessThan11SellIn_IncreasesQualityBy2()
    {
        var item = new ItemBuilder().AsBackstagePass().WithSellIn(10).WithQuality(20).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePassLessThan6SellIn_IncreasesQualityBy3()
    {
        var item = new ItemBuilder().AsBackstagePass().WithSellIn(5).WithQuality(20).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void UpdateQuality_ExpiredBackStagePass_GoesToZero()
    {
        var Item = new ItemBuilder().AsExpired().AsBackstagePass().WithQuality(20).Build();
        var app = new GildedRose([Item]);
        app.UpdateQuality();
        Assert.Equal(0, Item.Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_DoesNotChangeQuality()
    {
        var  item = new ItemBuilder().AsSulfuras().WithQuality(80).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_DoesNotChangeSellIn()
    {
        var item = new ItemBuilder().AsSulfuras().WithSellIn(70).Build();
        var app = new GildedRose([item]);
        app.UpdateQuality();
        Assert.Equal(70, item.SellIn);
        
    }

}

