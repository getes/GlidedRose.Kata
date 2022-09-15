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
                case "StandardItem":
                    _strategy = new StandardStrategy();
                    break;
                case "AgedBrie":
                    _strategy = new AgedBrieStrategy();
                    break;
                case "Conjured":
                    _strategy = new ConjuredStrategy();
                    break;
                case "BackStage":
                    _strategy = new BackStageStrategy();
                    break;
                case "Sulfuras":
                    _strategy = new SulfurasStrategy();
                    break;
                default:
                    return null;
            }

            return _strategy;
        }
    }
}
