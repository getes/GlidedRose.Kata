using GildedRose.Factories;
using System.Collections.Generic;
using System.Linq;

namespace GlidedRoseKata
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
            _items.ToList().ForEach(item => _itemFactory.CreateStrategyItem(item.Name).Update(item));
        }
    }
}
