using GildedRose.Contracts;
using GildedRoseKata;

namespace GildedRose.Strategies
{
    internal class BackStageStrategy : IItemsStrategy
    {
        public void Update(Item item)
        {
            _ = item.SellIn < 0
                ? item.Quality -= 2
                : item.Quality--;

            if (item.Quality < 0) { item.Quality = 0; }

            item.SellIn--;
        }
    }
}
