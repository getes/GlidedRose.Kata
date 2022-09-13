using System.Collections.Generic;
using NUnit.Framework;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void StandardUpdateQuality() //Pasado un dia un Articulo Standard decrementa SellIn -- y Quality --
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Item1", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(Items.Where(i => i.Name == "Item1").FirstOrDefault().Quality, Is.EqualTo(49));
            Assert.That(Items.Where(i => i.Name == "Item1").FirstOrDefault().SellIn, Is.EqualTo(9));
        }

        //Calidad de un artículo nunca negativa
        [Test]
        public void QualityNeverNegative()
        {

            //IList<Item> Items = new List<Item> { new Item { Name = "StandardItem", SellIn = 2, Quality = 0 } };
            IList<Item> Items = new List<Item> { TestHelpers.CreateStandardItem(TestHelpers.StandardItem, 2, 0) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().Quality, Is.EqualTo(0));
            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().SellIn, Is.EqualTo(1));

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().Quality, Is.EqualTo(0));
            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().SellIn, Is.EqualTo(0));

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().Quality, Is.EqualTo(0));
            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().SellIn, Is.EqualTo(-1));
        }

        //Items Sulfuras Quality Inmutable
        [Test]
        public void SulfurasIsInmutable()
        {
            IList<Item> Items = new List<Item> { TestHelpers.CreateSulfurasItem(10) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.Sulfuras).FirstOrDefault().Quality, Is.EqualTo(80));
            Assert.That(Items.Where(i => i.Name == TestHelpers.Sulfuras).FirstOrDefault().SellIn, Is.EqualTo(10));
        }

        //Queso Brie Aumenta Quality cada dia
        [Test]
        public void AgedBrieGrowsQuality()
        {
            int initialQuality = 20;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBrieItem(10, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().Quality, Is.EqualTo(initialQuality +1));
            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().SellIn, Is.EqualTo(9));
        }


        //Queso Brie pasada la SellIn date, aumenta de dos en dos
        [Test]
        public void AgedBrieGrowsQualityDoubleWhenSellinPassed()
        {
            int initialQuality = 20;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBrieItem(0, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().Quality, Is.EqualTo(initialQuality +2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().SellIn, Is.EqualTo(-1));
        }

        //Queso Brie nunca tiene Quality > 50
        [Test]
        public void AgedBrieNeverGrowsOver50()
        {
            int initialQuality = 50;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBrieItem(-5, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().Quality, Is.EqualTo(initialQuality));
            Assert.That(Items.Where(i => i.Name == TestHelpers.AgedBrie).FirstOrDefault().SellIn, Is.EqualTo(-6));
        }

        //BackStagePass Grow Quality x2 for SellIn 6 a 10
        [Test]
        public void BackStagePassQuality_x2_IfSellIn_Between_6_and_10()
        {
            int initialQuality = 1;
            int actualQuality = 1;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBackstageItem(10, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality+2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(9));

            actualQuality = actualQuality+2;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality+2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(8));

            actualQuality = actualQuality+2;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality+2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(7));

            actualQuality = actualQuality+2;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality+2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(6));
        }

        //BackStagePass Grow Quality x3 for SellIn 1 a 5
        [Test]
        public void BackStagePassQuality_x3_IfSellIn_Between_1_and_6()
        {
            int initialQuality = 1;
            int actualQuality = 1;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBackstageItem(5, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(4));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(3));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(2));

            actualQuality = actualQuality + 3;
            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(actualQuality + 3));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(1));
        }

        //BackStagePass Grow Quality = 0 for SellIn = 0
        [Test]
        public void BackStagePassQuality_0_forSellIn_0()
        {
            int initialQuality = 10;

            IList<Item> Items = new List<Item> { TestHelpers.CreateBackstageItem(0, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().Quality, Is.EqualTo(0));
            Assert.That(Items.Where(i => i.Name == TestHelpers.BackstagePass).FirstOrDefault().SellIn, Is.EqualTo(-1));
        }

        //When SellIn < 0 Quality Falls double 
        [Test]
        public void QualityDropsDoubleAfterSellIn() //Pasado fecha de venta un Articulo Standard decrementa SellIn -- y Quality x2
        {
            int initialQuality = 50;
            int initialSellIn = 0;

            //Arrange
            IList<Item> Items = new List<Item> {
                TestHelpers.CreateStandardItem(TestHelpers.StandardItem, initialSellIn, initialQuality)};
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().Quality, Is.EqualTo(48));
            Assert.That(Items.Where(i => i.Name == TestHelpers.StandardItem).FirstOrDefault().SellIn, Is.EqualTo(-1));
        }

        //Conjured Items Quality Falls Double than StandardItem
        [Test]
        public void ConjuredItemsFallsDoubleQuality()
        {
            int initialQuality = 50;
            int initialSellIn = 10;

            IList<Item> Items = new List<Item> { TestHelpers.CreateConjuredItem(initialSellIn, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.ConjuredItem).FirstOrDefault().Quality, Is.EqualTo(initialQuality - 2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.ConjuredItem).FirstOrDefault().SellIn, Is.EqualTo(initialSellIn-1));
        }

        //Conjured Quality Falls x4 when SellIn < 0 ????
        [Test]
        public void ConjuredItemsQualityFallsx4WhenSellInPassed()
        {
            int initialQuality = 50;
            int initialSellIn = 10;

            IList<Item> Items = new List<Item> { TestHelpers.CreateConjuredItem(initialSellIn, initialQuality) };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.That(Items.Where(i => i.Name == TestHelpers.ConjuredItem).FirstOrDefault().Quality, Is.EqualTo(initialQuality - 2));
            Assert.That(Items.Where(i => i.Name == TestHelpers.ConjuredItem).FirstOrDefault().SellIn, Is.EqualTo(initialSellIn - 1));
        }
    }
}
