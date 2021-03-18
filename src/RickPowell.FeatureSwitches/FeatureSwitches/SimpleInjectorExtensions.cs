using RickPowell.FeatureSwitches.FeatureSwitches.Services;
using SimpleInjector;

namespace RickPowell.FeatureSwitches.Core
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterFeatureSwitchesModule(this Container container)
        {
            container.Register<ISettingsService, SettingsService>();
        }
    }
}
