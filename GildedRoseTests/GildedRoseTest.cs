//using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using NUnit;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        //[Fact]
        //public void foo()
        //{
        //    IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        //    GildedRose app = new GildedRose(Items);
        //    app.UpdateQuality();
        //    Assert.Equal("fixme", Items[0].Name);
        //}

        [Test]
        private void test1()
        { 
        
        }

        //Standard Item Sellin Y Quality -1 cada dia si Sellin >= 0
        
        //Standard Item Sellin Y Quality -2 cada dia si SellIn< 0
        
        //Any Item Quality nunca menor de 0
        
        //Si es AgedBrie Quality +1 si Sellin >= 0
        
        //Si es AgedBrie Quality +2 si Sellin < 0
        
        //AgedBrie Quality nunca mayor de 50
        
        //NoneItem ExceptSulfuras Has Quality over50
        
        //Sulfuras No modifica SellIn ni Quality && Quality == 80
        
        //Si BackStage SellIn< 0 --> Quality = 0
        
        //Si es BackStage Quality +3 si Sellin >= 0 && SellIn <= 5
        
        //Si es BackStage Quality +2 si Sellin > 5 && SellIn <= 10
        
        //Si es BackStage Quality +1 si Sellin > 10
        
        //BackStage Quality nunca mayor de 50
        
        //Si es Conjured && SellIn >= 0 Quality -2
        
        //Si es Conjured && SellIn< 0 Quality -4
    }
}
