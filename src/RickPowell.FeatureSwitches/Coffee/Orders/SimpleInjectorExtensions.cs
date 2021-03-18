using RickPowell.FeatureSwitches.Coffee.Orders.Data;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee.Orders
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterOrdersSubmodule(this Container container)
        {
            container.RegisterOrdersContext();
        }
    }
}
