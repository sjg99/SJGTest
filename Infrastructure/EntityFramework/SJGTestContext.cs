using Core.Order.Domain.Model;
using Core.Product.Domain.Model;
using Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public partial class SJGTestContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Detail> Details { get; set; }

        public SJGTestContext()
        {
        }

        public SJGTestContext(DbContextOptions<SJGTestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new DetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
