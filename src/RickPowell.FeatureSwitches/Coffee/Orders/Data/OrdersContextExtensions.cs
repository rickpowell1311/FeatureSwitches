using RickPowell.FeatureSwitches.Coffee.Orders.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Data
{
    public static class OrdersContextExtensions
    {
        public static async Task RunMigrations(this OrdersContext context)
        {
            context.Blends.Add(Blend.Create("Columbian", new Cost(2m, Currency.Gbp)));

            await context.SaveChangesAsync();
        }
    }
}
