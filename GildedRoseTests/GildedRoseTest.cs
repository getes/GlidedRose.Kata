//using Xunit;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
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


        //Standard Item Sellin Y Quality -1 cada dia si Sellin >= 0
        [Test]
        public static void StandardItemSellIn_and_QualityDecreaseByOneWhenSellinGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(TestHelper.StandardItem, 10, 50)};
            GildedRose app = new (items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(9, items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.SellIn);
            Assert.AreEqual(49, items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.Quality);
        }


        //Standard Item Sellin Y Quality -2 cada dia si SellIn< 0
        [Test]
        public static void StandardItemSellIn_and_QualityDecreaseByTwoWhenSellinSmallerThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(TestHelper.StandardItem, 0, 50) };
            GildedRose app = new(items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(-1, items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.SellIn);
            Assert.AreEqual(48, items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.Quality);
        }

        //Any Item Quality nunca menor de 0

        //Si es AgedBrie Quality +1 si Sellin >= 0
        [Test]
        public static void AgedBrieSellIn_and_QualityIncreaseByOneWhenSellinGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(TestHelper.AgedBrie, 5, 15) };
            GildedRose app = new(items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(4, items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.SellIn);
            Assert.AreEqual(16, items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.Quality);
        }

        //Si es AgedBrie Quality +2 si Sellin < 0

        //AgedBrie Quality nunca mayor de 50
        [Test]
        public static void AgedBrieQuality_Never_GreaterThanFifty()
        {
            var items = new List<Item>() { TestHelper.ItemBuilder(TestHelper.AgedBrie, 10, 50) };
            GildedRose app = new(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.Quality);
        }


        [Test]
        public static void AgedBrieQuality_Never_GreaterThanFifty_WhenSellInSmallerThan_0()
        {
            var items = new List<Item>() { TestHelper.ItemBuilder(TestHelper.AgedBrie, -2, 50) };
            GildedRose app = new(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.Quality);
        }

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
