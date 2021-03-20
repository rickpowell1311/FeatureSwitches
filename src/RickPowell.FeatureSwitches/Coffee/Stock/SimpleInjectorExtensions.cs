using RickPowell.FeatureSwitches.Coffee.Stock.Services;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee.Stock
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterStockSubmodule(this Container container)
        {
            container.Register<IStockService, StockService>();
        }
    }
}
