using RickPowell.FeatureSwitches.Coffee.Supply.Services;
using RickPowell.FeatureSwitches.Coffee.Supply.Services.Trial;
using RickPowell.FeatureSwitches.Shared;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee.Supply
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterSupplySubmodule(this Container container)
        {
            // container.Register<ISupplierService, SupplierService>();

            container.RegisterServiceTransition<
                ISupplierService,
                UnprovenSupplierService,
                SupplierService,
                UnprovenSupplierServiceDecorator>();
        }
    }
}
