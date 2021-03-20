using MediatR;
using Microsoft.EntityFrameworkCore;
using RickPowell.FeatureSwitches.Coffee.Orders.Data;
using RickPowell.FeatureSwitches.Coffee.Orders.Domain;
using RickPowell.FeatureSwitches.Coffee.Stock.Services;
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
            private readonly IStockService _stockService;

            public Handler(OrdersContext context, IStockService stockService)
            {
                _context = context;
                _stockService = stockService;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var blend = await _context.Blends.SingleOrDefaultAsync(x => x.Name == request.Blend.Name);

                if (blend == null)
                {
                    throw new InvalidOperationException($"Blend '{request.Blend.Name}' unavailable");
                }

                var purchase = await Purchase.MakePurchase(
                        new Domain.Customer(request.Customer.Name),
                        blend,
                        request.Strength.ToStrength(),
                        _stockService);

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
