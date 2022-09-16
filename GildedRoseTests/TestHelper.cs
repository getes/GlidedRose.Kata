using GildedRoseKata;
using GildedRose.Common;

namespace GildedRoseTests
{
    public class TestHelper
    {
        public static Item ItemBuilder(string name, int sellIn = 10, int quality = 50)
        {
            Item item = new () { 
                Name = name, 
                SellIn = sellIn, 
                Quality = name == Constants.Sulfuras ? 80 : quality 
            };

            return item;
        }
    }
}
