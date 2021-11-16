using Hogwarts.DatabaseContext;
using Hogwarts.Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Boostrap
{
    public static class AddDbContextExtension
    {
        public static void AddDbContextService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(b => b
                    .UseSqlServer(configuration.Get<Settings>().ConnectionStrings.AzureHogwartsContext,
                    // TODO Change value of CommandTimeout after first run
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(45).TotalSeconds)));

            serviceCollection.AddScoped<ApplicationDbContext>();
        }
    }
}
