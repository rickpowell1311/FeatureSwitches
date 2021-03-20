using RickPowell.FeatureSwitches.Coffee.Stock.Domain;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Stock.Services.Deprecated
{
    public class StockService : IStockService
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
