using System.Collections.Generic;
using System.Linq;
using GildedRose.Common;
using GildedRoseKata;
using GildedRoseTests;
using NUnit.Framework;

namespace GlidedRoseTests
{
    [TestFixture]
    public class GlidedRoseTest
    {
        //Standard Item Sellin Y Quality -1 cada dia si Sellin >= 0
        [Test]
        public static void StandardItemSellIn_and_QualityDecreaseByOneWhenSellinGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(Constants.StandardItem, 10, 50) };
            GlidedRose app = new(items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(9, items.FirstOrDefault(item => item.Name == Constants.StandardItem)?.SellIn);
            Assert.AreEqual(49, items.FirstOrDefault(item => item.Name == Constants.StandardItem)?.Quality);
        }


        //Standard Item Sellin Y Quality -2 cada dia si SellIn< 0
        [Test]
        public static void StandardItemSellIn_and_QualityDecreaseByTwoWhenSellinSmallerThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(Constants.StandardItem, 0, 50) };
            GlidedRose app = new(items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(-1, items.FirstOrDefault(item => item.Name == Constants.StandardItem)?.SellIn);
            Assert.AreEqual(48, items.FirstOrDefault(item => item.Name == Constants.StandardItem)?.Quality);
        }

        //Si es AgedBrie Quality +1 si Sellin >= 0
        [Test]
        public static void AgedBrieSellIn_and_QualityIncreaseByOneWhenSellinGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.ItemBuilder(Constants.AgedBrie, 5, 15) };
            GlidedRose app = new(items);

            //Act
            app.UpdateQuality();


            //Assert
            Assert.AreEqual(4, items.FirstOrDefault(item => item.Name == Constants.AgedBrie)?.SellIn);
            Assert.AreEqual(16, items.FirstOrDefault(item => item.Name == Constants.AgedBrie)?.Quality);
        }

        //AgedBrie Quality nunca mayor de 50
        [Test]
        public static void AgedBrieQuality_Never_GreaterThanFifty()
        {
            var items = new List<Item>() { TestHelper.ItemBuilder(Constants.AgedBrie, 10, 50) };
            GlidedRose app = new(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items.FirstOrDefault(item => item.Name == Constants.AgedBrie)?.Quality);
        }

        //AgedBrie Quality Never Greater than 50 when SellIn < 0
        [Test]
        public static void AgedBrieQuality_Never_GreaterThanFifty_WhenSellInSmallerThan_0()
        {
            var items = new List<Item>() { TestHelper.ItemBuilder(Constants.AgedBrie, -2, 50) };
            GlidedRose app = new(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items.FirstOrDefault(item => item.Name == Constants.AgedBrie)?.Quality);
        }

        //NoneItem ExceptSulfuras Has Quality over50
        [Test]
        public static void NoneItemWillHave_QualityGreaterThan50()
        {
            var items = new List<Item>()
            {
                TestHelper.ItemBuilder(Constants.StandardItem, 10, 50),
                TestHelper.ItemBuilder(Constants.AgedBrie, 10, 50),
                TestHelper.ItemBuilder(Constants.AgedBrie, -1, 50),
                TestHelper.ItemBuilder(Constants.ConjuredItem, 10, 50),
                TestHelper.ItemBuilder(Constants.BackstagePass, 10, 50),
                TestHelper.ItemBuilder(Constants.BackstagePass, 4, 50),
                TestHelper.ItemBuilder(Constants.BackstagePass, 0, 50),
                TestHelper.ItemBuilder(Constants.BackstagePass, -1, 50),
            };

            GlidedRose app = new(items);
            app.UpdateQuality();

            Assert.That(!items.Any(i => i.Quality > 50));
        }

        //Calidad de un artículo standard nunca negativa
        [Test]
        public void QualityNeverNegative()
        {
            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.StandardItem, 2, 0) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).Quality, Is.EqualTo(0));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).SellIn, Is.EqualTo(1));

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).Quality, Is.EqualTo(0));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).SellIn, Is.EqualTo(0));

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).Quality, Is.EqualTo(0));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.StandardItem).SellIn, Is.EqualTo(-1));
        }

        //Items Sulfuras Quality Inmutable
        [Test]
        public void SulfurasIsInmutable()
        {
            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.Sulfuras) };
            GlidedRose app = new(Items);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.Sulfuras).Quality, Is.EqualTo(80));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.Sulfuras).SellIn, Is.EqualTo(10));
        }

        //Queso Brie Aumenta Quality cada dia
        [Test]
        public void AgedBrieGrowsQuality()
        {
            int initialQuality = 20;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.AgedBrie, 10, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).Quality, Is.EqualTo(initialQuality + 1));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).SellIn, Is.EqualTo(9));
        }

        //Queso Brie pasada la SellIn date, aumenta de dos en dos
        [Test]
        public void AgedBrieGrowsQualityDoubleWhenSellinPassed()
        {
            int initialQuality = 20;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.AgedBrie, 0, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).Quality, Is.EqualTo(initialQuality + 2));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).SellIn, Is.EqualTo(-1));
        }

        //Queso Brie nunca tiene Quality > 50
        [Test]
        public void AgedBrieNeverGrowsOver50()
        {
            int initialQuality = 50;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.AgedBrie, -5, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).Quality, Is.EqualTo(initialQuality));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.AgedBrie).SellIn, Is.EqualTo(-6));
        }

        //Si es BackStage Quality +1 si Sellin > 10
        [Test]
        public void BackStagePassQuality_GrowsOne_IfSellIn_GreaterThan_10()
        {
            int initialQuality = 30;
            int initialSellIn = 15;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.BackstagePass, initialSellIn, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(initialQuality + 1));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(initialSellIn -1));
        }

        //BackStagePass Grow Quality x2 for SellIn 6 a 10
        [Test]
        public void BackStagePassQuality_GrowsDouble_IfSellIn_Between_6_and_10()
        {
            int initialQuality = 1;
            int actualQuality = 1;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.BackstagePass, 10, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 2));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(9));

            actualQuality += 2;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 2));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(8));

            actualQuality += 2; ;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 2));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(7));

            actualQuality += 2;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 2));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(6));
        }

        //BackStagePass Grow Quality x3 for SellIn 1 a 5
        [Test]
        public void BackStagePassQuality_GrownTriple_IfSellIn_Between_1_and_6()
        {
            int initialQuality = 1;
            int actualQuality = 1;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.BackstagePass, 5, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(4));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(3));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(2));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(1));
        }

        //BackStagePass Grow Quality = 0 for SellIn = 0
        [Test]
        public void BackStagePassQuality_0_forSellIn_0()
        {
            int initialQuality = 10;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.BackstagePass, 0, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(0));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(-1));
        }

        //BackStagePass Quality Never > 50
        [Test]
        public void BackStageQualityNeverGrowsOver50()
        {
            int initialQuality = 50;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.BackstagePass, 2, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).Quality, Is.EqualTo(initialQuality));
            Assert.That(Items.FirstOrDefault(i => i.Name == Constants.BackstagePass).SellIn, Is.EqualTo(1));
        }

        //When SellIn < 0 Quality Falls double 
        [Test]
        public void QualityDropsDoubleAfterSellIn() //Pasado fecha de venta un Articulo Standard decrementa SellIn -- y Quality x2
        {
            int initialQuality = 50;
            int initialSellIn = 0;

            //Arrange
            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.StandardItem, initialSellIn, initialQuality) };
            GlidedRose app = new(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(Items.Where(i => i.Name == Constants.StandardItem).FirstOrDefault().Quality, Is.EqualTo(48));
            Assert.That(Items.Where(i => i.Name == Constants.StandardItem).FirstOrDefault().SellIn, Is.EqualTo(-1));
        }

        //Conjured Items Quality Falls Double than StandardItem
        [Test]
        public void ConjuredItemsFallsDoubleQuality()
        {
            int initialQuality = 50;
            int initialSellIn = 10;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.ConjuredItem, initialSellIn, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == Constants.ConjuredItem).FirstOrDefault().Quality, Is.EqualTo(initialQuality - 2));
            Assert.That(Items.Where(i => i.Name == Constants.ConjuredItem).FirstOrDefault().SellIn, Is.EqualTo(initialSellIn - 1));
        }

        //Conjured Quality Falls x4 when SellIn < 0 ????
        [Test]
        public void ConjuredItemsQualityFallsx4WhenSellInPassed()
        {
            int initialQuality = 50;
            int initialSellIn = 10;

            IList<Item> Items = new List<Item> { TestHelper.ItemBuilder(Constants.ConjuredItem, initialSellIn, initialQuality) };
            GlidedRose app = new(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == Constants.ConjuredItem).FirstOrDefault().Quality, Is.EqualTo(initialQuality - 2));
            Assert.That(Items.Where(i => i.Name == Constants.ConjuredItem).FirstOrDefault().SellIn, Is.EqualTo(initialSellIn - 1));
        }
    }
}
