using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests
{
    public class TestHelper
    {
        public const string StandardItem = "StandardItem";
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredItem = "Conjured Mana Cake";

        public static Item ItemBuilder(string name, int sellIn, int quality)
        {
            Item item = new () { 
                Name = name, 
                SellIn = sellIn, 
                Quality = quality 
            };

            return item;
        }
    }
}
