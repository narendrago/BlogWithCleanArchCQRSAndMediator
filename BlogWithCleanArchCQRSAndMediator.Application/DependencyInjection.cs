using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWithCleanArchCQRSAndMediator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // all the assembly for AutoMapper will execute and register here
            services.AddMediatR(ctg => {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            
            return services;
        }
    }
}