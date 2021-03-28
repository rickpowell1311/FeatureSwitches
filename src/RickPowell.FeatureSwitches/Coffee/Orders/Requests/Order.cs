using MediatR;
using Microsoft.EntityFrameworkCore;
using RickPowell.FeatureSwitches.Coffee.Orders.Data;
using RickPowell.FeatureSwitches.Coffee.Orders.Domain;
using RickPowell.FeatureSwitches.Coffee.Supply.Services;
using RickPowell.FeatureSwitches.FeatureSwitches.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Requests
{
    public static class Order
    {
        public class Request : IRequest
        {
            public Customer Customer { get; set; }

            public Blend Blend { get; set; }

            public Strength Strength { get; set; }
        }

        public class Customer
        {
            public string Name { get; set; }
        }

        public class Blend
        {
            public string Name { get; set; }
        }

        public enum Strength
        {
            Weak,
            Normal,
            Strong
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly OrdersContext _context;
            private readonly ISupplierService _supplierService;
            private readonly IFeatureSwitchService _featureSwitchService;

            public Handler(
                OrdersContext context, 
                ISupplierService supplierService, 
                IFeatureSwitchService featureSwitchService)
            {
                _context = context;
                _supplierService = supplierService;
                _featureSwitchService = featureSwitchService;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var blend = await _context.Blends.SingleOrDefaultAsync(x => x.Name == request.Blend.Name);

                if (blend == null)
                {
                    throw new InvalidOperationException($"Blend '{request.Blend.Name}' unavailable");
                }

                var featureSwitches = await _featureSwitchService.GetFeatureSwitches();

                var purchase = await Purchase.MakePurchase(
                    new Domain.Customer(request.Customer.Name),
                    blend,
                    request.Strength.ToStrength(),
                    _supplierService,
                    featureSwitches.UseExerimentalPricing);

                _context.Purchases.Add(purchase);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }

    public static class StrengthExtensions
    {
        public static Strength ToStrength(this Order.Strength strength)
        {
            return strength switch
            {
                Order.Strength.Weak => Strength.Weak,
                Order.Strength.Normal => Strength.Normal,
                Order.Strength.Strong => Strength.Strong,
                _ => throw new NotImplementedException($"Strength '{strength}' is undefined"),
            };
        }
    }
}
