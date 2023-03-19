using IXORA.PlatonovNikita.TestShop.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IXORA.PlatonovNikita.TestShop.Context
{
    public class TestShopContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public TestShopContext(DbContextOptions<TestShopContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
