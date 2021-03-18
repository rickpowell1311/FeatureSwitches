using MediatR;
using MediatR.SimpleInjector;
using RickPowell.FeatureSwitches.Coffee;
using RickPowell.FeatureSwitches.Coffee.Orders.Data;
using RickPowell.FeatureSwitches.Coffee.Orders.Requests;
using RickPowell.FeatureSwitches.Core;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.BuildMediator(typeof(Program).Assembly);
            container.RegisterCoffeeModule();
            container.RegisterFeatureSwitchesModule();
            container.Verify();

            using var scope = AsyncScopedLifestyle.BeginScope(container);
            await scope.GetInstance<OrdersContext>().RunMigrations();
            var mediator = scope.GetInstance<IMediator>();

            try
            {
                await mediator.Send(new Order.Request
                {
                    Blend = new Order.Blend { Name = "Columbian" },
                    Customer = new Order.Customer { Name = "Joe Bloggs" },
                    Strength = Order.Strength.Strong
                });

                Console.WriteLine("Fund purchase was successfully made :)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fund purchase could not be made :(. {ex.Message}.");
            }

            Console.ReadKey();
        }
    }
}
