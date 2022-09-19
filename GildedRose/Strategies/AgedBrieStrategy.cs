using GildedRose.Contracts;
using GlidedRoseKata;

namespace GildedRose.Strategies
{
    internal class AgedBrieStrategy : IItemsStrategy
    {
        public void Update(Item item)
        {
            _ = item.SellIn <= 0
                ? item.Quality += 2
                : item.Quality ++;

            if (item.Quality < 0) { item.Quality = 0; }
            if(item.Quality > 50) { item.Quality = 50; }

            item.SellIn--;
        }
    }
}
