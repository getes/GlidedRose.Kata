//using Xunit;
using System.Collections.Generic;
using NUnit.Framework;
using GildedRoseKata;
using System.Linq;

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
        public void StandardUpdateQuality() //Pasado un dia un Articulo Standard decrementa SellIn -- y Quality --
        {
            //Arrange
            //Should be ONE item of each type
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

            IList<Item> Items = new List<Item> { new Item { Name = "StandardItem", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(Items.Where(i => i.Name == "Item1").FirstOrDefault().Quality, Is.EqualTo(49));
            Assert.That(Items.Where(i => i.Name == "Item1").FirstOrDefault().SellIn, Is.EqualTo(9));
        }

        //Pasado un dia un Articulo Standard decrementa SellIn -- y Quality --
    }
}
