using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Data
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterOrdersContext(this Container container)
        {
            var marketContextBuilder = new DbContextOptionsBuilder<OrdersContext>();
            marketContextBuilder.UseInMemoryDatabase("OrdersContext");

            container.Register(() => new OrdersContext(marketContextBuilder.Options), Lifestyle.Scoped);
        }
    }
}
