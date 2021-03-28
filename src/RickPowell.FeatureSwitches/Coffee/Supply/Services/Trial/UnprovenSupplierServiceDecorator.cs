using RickPowell.FeatureSwitches.Coffee.Supply.Domain;
using RickPowell.FeatureSwitches.FeatureSwitches.Services;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Supply.Services.Trial
{
    public class UnprovenSupplierServiceDecorator : ISupplierService
    {
        private readonly SupplierService _normal;
        private readonly UnprovenSupplierService _trial;
        private readonly IFeatureSwitchService _featureSwitchService;

        public UnprovenSupplierServiceDecorator(
            SupplierService normal,
            UnprovenSupplierService trial,
            IFeatureSwitchService featureSwitchService)
        {
            _normal = normal;
            _trial = trial;
            _featureSwitchService = featureSwitchService;
        }

        public async Task<Quantity> GetQuantity(Blend blend)
        {
            var featureSwitches = await _featureSwitchService.GetFeatureSwitches();

            if (featureSwitches.UseTemporarySupplier)
            {
                return await _trial.GetQuantity(blend);
            }

            return await _normal.GetQuantity(blend);
        }
    }
}
