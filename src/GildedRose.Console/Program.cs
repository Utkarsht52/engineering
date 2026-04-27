using System.Collections.Generic;

namespace GildedRose.Console;

public class Program
{
    public IList<Item> Items = new List<Item>();

    static void Main(string[] args) {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program() {
            Items = new List<Item>
                                      {
                                          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                          new Item
                                              {
                                                  Name = "Backstage passes to a TAFKAL80ETC concert",
                                                  SellIn = 15,
                                                  Quality = 20
                                              },
                                          new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                      }

        };

        app.UpdateQuality();

        System.Console.ReadKey();
    }


    public void UpdateQuality() {
        foreach (var item in Items) {
            switch (item.Name) {
                case "Sulfuras, Hand of Ragnaros":
                    // Since no action performed in this code
                    break;

                case "Aged Brie":

                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item);
                    break;
                case var name when name.StartsWith("Conjured"):
                    UpdateConjuredItem(item);
                    break;
                default:
                    UpdateNormalItem(item);
                    break;
            }
        }
    }

    private static void UpdateConjuredItem(Item item) {
        DecreaseQuality(item);
        DecreaseQuality(item);

        item.SellIn--;

        if (item.SellIn < 0) {
            DecreaseQuality(item);
            DecreaseQuality(item);
        }
    }

    private static void UpdateNormalItem(Item item) {
        DecreaseQuality(item);

        item.SellIn--;

        if (item.SellIn < 0)
            DecreaseQuality(item);
    }


    private static void UpdateAgedBrie(Item item) {
        // Since Item is getting increased by 1, if less than 50
        IncreaseQuality(item);
        // Since After increasing quantity is decreased by 1
        item.SellIn--;

        // If sell in is less than 0, then Updaying Increase Quality
        if (item.SellIn < 0)
            IncreaseQuality(item);
    }
    private static void UpdateBackstagePass(Item item) {
        IncreaseQuality(item);

        if (item.SellIn < 11)
            IncreaseQuality(item);

        if (item.SellIn < 6)
            IncreaseQuality(item);

        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality = 0;
    }


    private static void IncreaseQuality(Item item) {
        if (item.Quality < 50)
            item.Quality++;
    }

    private static void DecreaseQuality(Item item) {
        if (item.Quality > 0)
            item.Quality--;
    }

    //public void UpdateQuality() {
    //    for (var i = 0; i < Items.Count; i++) {
    //        if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
    //            if (Items[i].Quality > 0) {
    //                if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
    //                    Items[i].Quality = Items[i].Quality - 1;
    //                }
    //            }
    //        }
    //        else {
    //            if (Items[i].Quality < 50) {
    //                Items[i].Quality = Items[i].Quality + 1;

    //                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") {
    //                    if (Items[i].SellIn < 11) {
    //                        if (Items[i].Quality < 50) {
    //                            Items[i].Quality = Items[i].Quality + 1;
    //                        }
    //                    }

    //                    if (Items[i].SellIn < 6) {
    //                        if (Items[i].Quality < 50) {
    //                            Items[i].Quality = Items[i].Quality + 1;
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
    //            Items[i].SellIn = Items[i].SellIn - 1;
    //        }

    //        if (Items[i].SellIn < 0) {
    //            if (Items[i].Name != "Aged Brie") {
    //                if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
    //                    if (Items[i].Quality > 0) {
    //                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
    //                            Items[i].Quality = Items[i].Quality - 1;
    //                        }
    //                    }
    //                }
    //                else {
    //                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
    //                }
    //            }
    //            else {
    //                if (Items[i].Quality < 50) {
    //                    Items[i].Quality = Items[i].Quality + 1;
    //                }
    //            }
    //        }
    //    }
    //}
}

public class Item
{
    public string Name { get; set; } = "";

    public int SellIn { get; set; }

    public int Quality { get; set; }
}
