using RickPowell.FeatureSwitches.Coffee.Stock.Services;
using System;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Domain
{
    public class Purchase
    {
        public int Id { get; protected set; }

        public Cost Cost { get; protected set; }

        public Customer Customer { get; protected set; }

        private Purchase()
        {
        }

        public static Func<Customer, Blend, Strength, IStockService, Task<Purchase>> MakePurchase(
            bool useCovidContingencyPurchasePricing)
        {
            if (useCovidContingencyPurchasePricing)
            {
                return MakeCovidContingencyPurchase;
            }

            return MakePurchase;
        }

        private static async Task<Purchase> MakePurchase(
            Customer customer, 
            Blend blend,
            Strength strength, 
            IStockService stockService)
        {
            var quantity = await stockService.GetQuantity(new Stock.Services.Blend { Name = blend.Name });

            if (strength.Kilograms > quantity.Kilograms)
            {
                throw new InvalidOperationException("Not enough coffee :(");
            }

            return new Purchase
            {
                Cost = blend.GetCost(strength),
                Customer = new Customer(customer.Name)
            };
        }

        private static async Task<Purchase> MakeCovidContingencyPurchase(
            Customer customer,
            Blend blend,
            Strength strength,
            IStockService stockService)
        {
            var covidContingencyFee = 0.5m;

            var purchase = await MakePurchase(customer, blend, strength, stockService);
            purchase.Cost += covidContingencyFee;

            return purchase;
        }
    }
}
