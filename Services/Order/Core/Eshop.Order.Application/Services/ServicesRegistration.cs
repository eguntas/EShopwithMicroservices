using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Order.Application.Services
{
    public static class ServicesRegistration
    {
        public static void AddApplicationService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServicesRegistration).Assembly));
        }
    }
}
