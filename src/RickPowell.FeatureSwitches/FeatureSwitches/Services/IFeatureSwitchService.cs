using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.FeatureSwitches.Services
{
    public interface IFeatureSwitchService
    {
        Task<FeatureSwitches> GetFeatureSwitches();
    }
}
