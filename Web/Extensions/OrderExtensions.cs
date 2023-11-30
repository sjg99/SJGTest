using Core.Order.App;
using Core.Order.Domain.Services;
using Infrastructure.Repositories;

namespace Web.Extensions
{
    public static class OrderExtensions
    {
        public static void AddOrderServices(this IServiceCollection services)
        {
            services.AddScoped<OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
