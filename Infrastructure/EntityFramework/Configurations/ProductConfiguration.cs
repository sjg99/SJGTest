using Core.Product.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.IsSandwich)
                .IsRequired();

            builder.Property(p => p.IsFries)
                .IsRequired();

            builder.Property(p => p.IsDrink)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("357a5f62-89f9-4e68-80e1-a94be2fc06d3"),
                    Name = "X Burguer",
                    Price = 5,
                    IsSandwich = true,
                    IsFries = false,
                    IsDrink = false,
                    IsActive = true,
                    Created = new DateTime(2023, 3, 28),
                },
                new Product
                {
                    Id = Guid.Parse("264fd9cd-ec97-44d0-840d-f67962d3761c"),
                    Name = "X Egg",
                    Price = 4.5,
                    IsSandwich = true,
                    IsFries = false,
                    IsDrink = false,
                    IsActive = true,
                    Created = new DateTime(2023, 3, 28),
                },
                new Product
                {
                    Id = Guid.Parse("8d26a9b2-774a-467b-a3ad-4f59bcc75bd2"),
                    Name = "X Bacon",
                    Price = 7,
                    IsSandwich = true,
                    IsFries = false,
                    IsDrink = false,
                    IsActive = true,
                    Created = new DateTime(2023, 3, 28),
                },
                new Product
                {
                    Id = Guid.Parse("eb673ac1-9dfb-46a0-815e-115dcb078668"),
                    Name = "Fries",
                    Price = 2,
                    IsSandwich = false,
                    IsFries = true,
                    IsDrink = false,
                    IsActive = true,
                    Created = new DateTime(2023, 3, 28),
                },
                new Product
                {
                    Id = Guid.Parse("51928c2f-2587-4489-8b81-b4291232c7ea"),
                    Name = "Soft Drink",
                    Price = 2.5,
                    IsSandwich = false,
                    IsFries = false,
                    IsDrink = true,
                    IsActive = true,
                    Created = new DateTime(2023, 3, 28),
                });
        }
    }
}
