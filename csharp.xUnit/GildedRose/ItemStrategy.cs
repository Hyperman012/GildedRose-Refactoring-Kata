namespace GildedRoseKata;

public class ItemStrategy(Item item)
{
    public bool IsExpired()
    {
        return item.SellIn < 0;
    }

    public virtual void HandleExpired()
    {
        if (item.Quality > 0) // normal item
        {
            item.Quality -= 1;
        }
    }

    public virtual void UpdateSellIn()
    {
        item.SellIn -= 1;
    }

    public virtual void HandleQuality()
    {
        DecrementQualityIfAboveMin();
    }

    private void DecrementQualityIfAboveMin()
    {
        if (item.Quality > 0) 
        {
            item.Quality -= 1;
        }
    }

    protected void IncrementQualityIfUnderMax()
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

    public void ProcessItem()
    {
        HandleQuality();

        UpdateSellIn();

        if (IsExpired())
        {
            HandleExpired();
        }
    }
}

