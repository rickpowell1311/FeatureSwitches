using MediatR;
using Microsoft.EntityFrameworkCore;
using RickPowell.FeatureSwitches.Coffee.Orders.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Requests
{
    public static class GetPurchases
    {
        public class Request : IRequest<Response>
        {
        }

        public class Response
        {
            public List<Purchase> Purchases { get; set; }

            public Response()
            {
                Purchases = new List<Purchase>();
            }
        }

        public class Purchase
        {
            public Customer Customer { get; set; }

            public string Cost { get; set; }
        }

        public class Customer
        {
            public string Name { get; set; }
        }

        public class RequestHandler : IRequestHandler<Request, Response>
        {
            private readonly OrdersContext _context;

            public RequestHandler(OrdersContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var purchases = await _context.Purchases.ToListAsync();

                return new Response
                {
                    Purchases = purchases
                        .Select(x => new Purchase
                        {
                            Cost = x.Cost.ToString(),
                            Customer = new Customer { Name = x.Customer.Name }
                        })
                        .ToList()
                };
            }
        }
    }
}
