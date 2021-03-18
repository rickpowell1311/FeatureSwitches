using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.FeatureSwitches.Services
{
    public class SettingsService : ISettingsService
    {
        public Task<Settings> GetSettings()
        {
            var result = new Settings();

            return Task.FromResult(result);
        }
    }
}
