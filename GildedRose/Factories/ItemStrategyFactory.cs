using GildedRose.Contracts;
using GildedRose.Strategies;
using GildedRoseKata;

namespace GildedRose.Factories
{
    internal class ItemStrategyFactory
    {
        private IItemsStrategy _strategy;

        public IItemsStrategy CreateStrategyItem(string name)
        {
            switch (name)
            {
                case "Standard":
                    _strategy = new StandardStrategy();
                    break;
                case "AgedBrie":
                    break;
                case "Conjured":
                    break;
                case "BackStage":
                    break;
                case "Sulfuras":
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}
