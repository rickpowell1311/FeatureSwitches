using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.FeatureSwitches.Services
{
    public interface ISettingsService
    {
        Task<Settings> GetSettings();
    }
}
