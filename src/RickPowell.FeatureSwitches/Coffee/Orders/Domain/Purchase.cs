using RickPowell.FeatureSwitches.Coffee.Supply.Services;
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

        public static async Task<Purchase> MakePurchase(
            Customer customer, 
            Blend blend,
            Strength strength, 
            ISupplierService supplierService,
            bool useExperimentalPricing)
        {
            var quantity = await supplierService.GetQuantity(new Supply.Services.Blend { Name = blend.Name });

            if (strength.KilogramsOfCoffee > quantity.Kilograms)
            {
                throw new InvalidOperationException("Not enough coffee :(");
            }

            return new Purchase
            {
                Cost = blend.GetCost(useExperimentalPricing)(strength),
                Customer = new Customer(customer.Name)
            };
        }
    }
}
