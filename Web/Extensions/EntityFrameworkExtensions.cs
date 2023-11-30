using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static void AddEntityFrameworkServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SJGTestContext>(c =>
            {
                c.UseMySql(configuration.GetConnectionString("DBConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DBConnection")));
            });
        }
    }
}
