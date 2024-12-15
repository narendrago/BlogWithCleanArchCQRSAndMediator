using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using BlogWithCleanArchCQRSAndMediator.Infrastructure.Data;
using BlogWithCleanArchCQRSAndMediator.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWithCleanArchCQRSAndMediator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlite<BlogDbContext>(configuration.GetConnectionString("Blogs"));
            services.AddTransient<IBlogRepository, BlogRepository>();  // TODO: Why? 
            return services;
        }
    }
}