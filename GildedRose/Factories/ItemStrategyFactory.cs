using GildedRose.Contracts;
using GildedRose.Strategies;
using GildedRose.Common;
using System;

namespace GildedRose.Factories
{
    internal class ItemStrategyFactory
    {
        private IItemsStrategy _strategy;

        public IItemsStrategy CreateStrategyItem(string name)
        {
            switch (name)
            {
                case Constants.StandardItem:
                    _strategy = new StandardStrategy();
                    break;
                case Constants.AgedBrie:
                    _strategy = new AgedBrieStrategy();
                    break;
                case Constants.ConjuredItem:
                    _strategy = new ConjuredStrategy();
                    break;
                case Constants.BackstagePass:
                    _strategy = new BackStageStrategy();
                    break;
                case Constants.Sulfuras:
                    _strategy = new SulfurasStrategy();
                    break;
                default:
                    throw new Exception ($"Strategy Not Found: {name}");
            }

            return _strategy;
        }
    }
}
