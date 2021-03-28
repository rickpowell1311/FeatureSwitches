using RickPowell.FeatureSwitches.Coffee.Supply.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Supply.Services.Trial
{
    public class UnprovenSupplierService : ISupplierService
    {
        public Task<Quantity> GetQuantity(Blend blend)
        {
            return Task.FromResult(new Quantity
            {
                Kilograms = 100m
            });
        }
    }
}
