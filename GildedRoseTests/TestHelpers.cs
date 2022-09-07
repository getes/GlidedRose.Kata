using GildedRoseKata;

namespace GildedRoseTests
{
    internal class TestHelpers
    {
        public const string StandardItem = "StandardItem";
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredItem = "Conjured Mana Cake";

        public static Item CreateStandardItem(string name, int sellIn = 10, int quality = 50)
        {
            return new Item() { Name = name, SellIn = sellIn, Quality = quality };
        }

        public static Item CreateBrieItem(int sellIn = 10, int quality = 50)
        {
            return new Item() { Name = AgedBrie, SellIn = sellIn, Quality = quality };
        }

        public static Item CreateSulfurasItem(int sellIn = 10)
        {
            return new Item { Name = Sulfuras, SellIn = sellIn, Quality = 80 };

        }
        public static Item CreateBackstageItem(int sellIn = 10, int quality = 50)
        {
            return new Item
            {
                Name = BackstagePass,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public static Item CreateConjuredItem(int sellIn = 10, int quality = 50)
        {
            return new Item { Name = ConjuredItem, SellIn = sellIn, Quality = quality };

        }
    }
}
