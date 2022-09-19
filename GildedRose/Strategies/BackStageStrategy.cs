using GildedRose.Contracts;
using GlidedRoseKata;

namespace GildedRose.Strategies
{
    internal class BackStageStrategy : IItemsStrategy
    {
        public void Update(Item item)
        {
            switch (item.SellIn)
            {
                case <= 0:
                    item.Quality = 0;
                    break;
                case 1 or 2 or 3 or 4 or 5:
                    item.Quality += 3;
                    break;
                case 6 or 7 or 8 or 9 or 10:
                    item.Quality += 2;
                    break;
                default:
                    item.Quality ++;
                    break;
            }

            if (item.Quality < 0) { item.Quality = 0; }
            if (item.Quality > 50) { item.Quality = 50; }

            item.SellIn--;
        }
    }
}
