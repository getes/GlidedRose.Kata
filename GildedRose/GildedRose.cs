using GildedRose.Factories;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GlidedRose
    {
        private ItemStrategyFactory _itemFactory;
        IList<Item> Items;
        public GlidedRose(IList<Item> Items)
        {
            this.Items = Items;
            _itemFactory = new ItemStrategyFactory();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                var strategy = _itemFactory.CreateStrategyItem(item.Name);
                strategy.Update(item);
            }
        }
    }
}
