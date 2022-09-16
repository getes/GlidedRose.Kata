using GildedRose.Contracts;
using GildedRoseKata;

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
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    item.Quality += 3;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    item.Quality += 2;
                    break;
                default:
                    item.Quality += 1;
                    break;
            }

            if (item.Quality < 0) { item.Quality = 0; }

            item.SellIn--;
        }
    }
}
