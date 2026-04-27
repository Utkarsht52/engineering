using Xunit;

namespace GildedRose.Tests;

public class TestAssemblyTests
{
    [Fact]
public void NormalItem_Decreases_Quality_And_SellIn() {
    var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(9, item.SellIn);
    Assert.Equal(19, item.Quality);
}

[Fact]
public void NormalItem_Quality_Degrades_Twice_After_SellDate() {
    var item = new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(-1, item.SellIn);
    Assert.Equal(8, item.Quality);
}

[Fact]
public void NormalItem_Quality_Never_Goes_Below_Zero() {
    var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 0 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(0, item.Quality);
}

[Fact]
public void AgedBrie_Increases_Quality() {
    var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(1, item.Quality);
    Assert.Equal(1, item.SellIn);
}

[Fact]
public void AgedBrie_Increases_Twice_After_SellDate() {
    var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(-1, item.SellIn);
    Assert.Equal(12, item.Quality);
}

[Fact]
public void AgedBrie_Quality_Never_Exceeds_50() {
    var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(50, item.Quality);
}

[Fact]
public void Sulfuras_Does_Not_Change() {
    var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(0, item.SellIn);
    Assert.Equal(80, item.Quality);
}

[Fact]
public void BackstagePass_Increases_By_One_When_More_Than_10_Days() {
    var item = new Item {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 15,
        Quality = 20
    };

    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(14, item.SellIn);
    Assert.Equal(21, item.Quality);
}

[Fact]
public void BackstagePass_Increases_By_Two_When_10_Days_Or_Less() {
    var item = new Item {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 10,
        Quality = 20
    };

    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(9, item.SellIn);
    Assert.Equal(22, item.Quality);
}

[Fact]
public void BackstagePass_Increases_By_Three_When_5_Days_Or_Less() {
    var item = new Item {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 5,
        Quality = 20
    };

    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(4, item.SellIn);
    Assert.Equal(23, item.Quality);
}

[Fact]
public void BackstagePass_Quality_Drops_To_Zero_After_Concert() {
    var item = new Item {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 0,
        Quality = 20
    };

    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(-1, item.SellIn);
    Assert.Equal(0, item.Quality);
}

[Fact]
public void BackstagePass_Quality_Never_Exceeds_50() {
    var item = new Item {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 5,
        Quality = 49
    };

    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(50, item.Quality);
}

[Fact]
public void ConjuredItem_Quality_Never_Goes_Below_Zero() {
    var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 3 };
    var app = new Program { Items = new List<Item> { item } };

    app.UpdateQuality();

    Assert.Equal(-1, item.SellIn);
    Assert.Equal(0, item.Quality);
}
}
