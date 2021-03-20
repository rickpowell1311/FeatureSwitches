using RickPowell.FeatureSwitches.Coffee.Stock.Services;
using RickPowell.FeatureSwitches.Coffee.Stock.Services.Deprecated;
using RickPowell.FeatureSwitches.Shared;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee.Stock
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterStockSubmodule(this Container container)
        {
            container.RegisterServiceTransition<
                IStockService, 
                Services.StockService, 
                Services.Deprecated.StockService, 
                StockServiceDeprecationDecorator>();

            // container.Register<IStockService, StockService>();
        }
    }
}
