using RickPowell.FeatureSwitches.Coffee.Supply.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Supply.Services
{
    public class SupplierService : ISupplierService
    {
        public Task<Quantity> GetQuantity(Blend blend)
        {
            return Task.FromResult(new Quantity
            {
                Kilograms = 0m
            });
        }
    }
}
