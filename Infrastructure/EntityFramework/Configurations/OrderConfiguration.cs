using Core.Order.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.TotalAmount)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();
        }
    }
}

