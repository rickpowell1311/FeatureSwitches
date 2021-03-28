using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.FeatureSwitches.Services
{
    public class FeatureSwitchService : IFeatureSwitchService
    {
        public Task<FeatureSwitches> GetFeatureSwitches()
        {
            return Task.FromResult(new FeatureSwitches
            {
                UseTemporarySupplier = true
            });
        }
    }
}
