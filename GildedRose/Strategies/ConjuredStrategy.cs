using GildedRose.Contracts;
using GildedRoseKata;

namespace GildedRose.Strategies
{
    internal class ConjuredStrategy : IItemsStrategy
    {
        public void Update(Item item)
        {
            _ = item.SellIn < 0
                ? item.Quality -= 4
                : item.Quality -= 2;

            if (item.Quality < 0) { item.Quality = 0; }

            item.SellIn--;
        }
    }
}
