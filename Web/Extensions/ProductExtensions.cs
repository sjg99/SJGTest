using Core.Product.App;
using Core.Product.Domain.Services;
using Infrastructure.Repositories;

namespace Web.Extensions
{
    public static class ProductExtensions
    {
        public static void AddProductServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
