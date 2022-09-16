using GildedRose.Factories;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GlidedRose
    {
        private readonly ItemStrategyFactory _itemFactory;
        readonly IList<Item> _items;

        public GlidedRose(IList<Item> Items)
        {
            this._items = Items;
            _itemFactory = new ItemStrategyFactory();
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                var strategy = _itemFactory.CreateStrategyItem(item.Name);
                strategy.Update(item);
            }
        }
    }
}
