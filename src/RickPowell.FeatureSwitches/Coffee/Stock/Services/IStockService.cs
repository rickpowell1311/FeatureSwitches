using RickPowell.FeatureSwitches.Coffee.Stock.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Stock.Services
{
    public interface IStockService
    {
        Task<Quantity> GetQuantity(Blend blend);
    }
}
