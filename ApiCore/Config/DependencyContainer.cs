using AutoMapper;
using Hogwarts.DatabaseContext.Repository;
using Hogwarts.Domain.Configuration;
using Hogwarts.Domain.Repository;
using Hogwarts.Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCore.Config
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.Configure<Settings>(configuration);

            // Add Repositories
            services.AddScoped<IRequestLoginRepository, RequestLoginRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            // Add Aplication Services
            services.AddScoped<IRequestLoginService, RequestLoginService>();
            services.AddScoped<IHomeService, HomeService>();
        }
    }
}
