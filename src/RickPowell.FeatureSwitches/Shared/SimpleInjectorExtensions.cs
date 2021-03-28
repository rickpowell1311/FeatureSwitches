using SimpleInjector;

namespace RickPowell.FeatureSwitches.Shared
{
    public static class SimpleInjectorExtensions
    {
        public static void RegisterServiceTransition<TService, TNewImplementation, TOldImplementation, TDecorator>(
            this Container container,
            Lifestyle lifestyle = null)
                where TNewImplementation : class, TService
                where TOldImplementation : class, TService
                where TDecorator : class, TService
        {
            lifestyle ??= Lifestyle.Transient;

            container.Register(typeof(TNewImplementation), typeof(TNewImplementation), lifestyle);
            container.Register(typeof(TOldImplementation), typeof(TOldImplementation), lifestyle);
            container.Register<TDecorator>(lifestyle);
            container.Register(typeof(TService), typeof(TDecorator), lifestyle);
        }
    }
}
