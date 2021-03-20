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

                var response = await mediator.Send(new GetPurchases.Request());

                foreach (var purchase in response.Purchases)
                {
                    Console.WriteLine($"{purchase.Customer.Name} bought a coffee for '{purchase.Cost}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong :(. {ex.Message}.");
            }
        }
    }
}
