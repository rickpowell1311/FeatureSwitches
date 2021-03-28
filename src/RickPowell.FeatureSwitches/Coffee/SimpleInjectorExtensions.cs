using RickPowell.FeatureSwitches.Coffee.Orders;
using RickPowell.FeatureSwitches.Coffee.Supply;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterCoffeeModule(this Container container)
        {
            container.RegisterSupplySubmodule();
            container.RegisterOrdersSubmodule();
        }
    }
}
