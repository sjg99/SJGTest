using Core.Order.Domain.Model;
using Core.Product.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    internal class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable("Detail");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.OrderId)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasOne<Product>().WithMany().HasForeignKey(p => p.ProductId);
        }
    }
}
