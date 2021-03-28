using RickPowell.FeatureSwitches.Coffee.Supply.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Supply.Services
{
    public interface ISupplierService
    {
        Task<Quantity> GetQuantity(Blend blend);
    }
}
