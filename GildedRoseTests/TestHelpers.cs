using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests
{
    internal class TestHelpers
    {
        public Item CreateStandardItem(string name, int sellIn = 10, int quality = 50)
        {
            return new Item() { Name = name, SellIn = sellIn, Quality = quality };
        }

        public Item CreateBrieItem(int sellIn = 10, int quality = 50)
        {
            return new Item() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        public Item CreateSulfurasItem(int sellIn = 10)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 };

        }
        public Item CreateBackstageItem(int sellIn = 10, int quality = 50)
        {
            return new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };
        }

        public Item CreateConjuredItem(int sellIn = 10, int quality = 50)
        {
            return new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };

        }
    }
}
