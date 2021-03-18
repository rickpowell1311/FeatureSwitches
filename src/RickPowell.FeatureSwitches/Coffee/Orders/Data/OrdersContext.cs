using Microsoft.EntityFrameworkCore;
using RickPowell.FeatureSwitches.Coffee.Orders.Domain;

namespace RickPowell.FeatureSwitches.Coffee.Orders.Data
{
    public class OrdersContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Blend> Blends { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var purchaseEntity = modelBuilder.Entity<Purchase>();
            purchaseEntity.OwnsOne(x => x.Customer);
            purchaseEntity.OwnsOne(x => x.Cost);

            var blendEntity = modelBuilder.Entity<Blend>();
            blendEntity.OwnsOne(x => x.BaseCost);
        }
    }
}
