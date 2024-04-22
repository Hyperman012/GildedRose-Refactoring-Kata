const {Shop} = require("../src/gilded_rose");
const { Item} = require("../src/item");

describe("Gilded Rose", function() {

  it("degrades quality on normal item", function() {
    const gildedRose = new Shop([new Item("bread", 10, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(9);
  });

  it('decreases quality by 2 when expired', () => {
    const gildedRose = new Shop([new Item("bread", 0, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(8);
  });
  it('quality is never negative ', () => {
    const gildedRose = new Shop([new Item("bread", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });


  it("decreases sell date on normal item", function() {
    const gildedRose = new Shop([new Item("bread", 10, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].sellIn).toBe(9);
  });


  it('Aged Brie goes up in quality', () => {
    const gildedRose = new Shop([new Item("Aged Brie", 10, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].sellIn).toBe(9);
    expect(items[0].quality).toBe(11);
  });

  it('sulfuras never changes', () => {
    const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 10, 80)]);
    const items = gildedRose.updateQuality();
    expect(items[0].sellIn).toBe(10);
    expect(items[0].quality).toBe(80);
  });

  it('quality never goes above 50', () => {
    const gildedRose = new Shop([new Item("Aged Brie", 10, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0].sellIn).toBe(9);
    expect(items[0].quality).toBe(50);
  });


  describe("Backstage pass", function() {
    it('updates quality by 2 if under 10 days ', () => {
      const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 9, 10)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(8);
      expect(items[0].quality).toBe(12);
    });

    it('updates quality by 3 if under 5 days ', () => {
      const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 4, 10)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(3);
      expect(items[0].quality).toBe(13);
    });
    it('updates quality to 0 if expired ', () => {
      const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(0);
    });

  });




  });
