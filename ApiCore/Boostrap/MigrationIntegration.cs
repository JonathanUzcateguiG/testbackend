using Hogwarts.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Boostrap
{
    public static class MigrationIntegrationExtension
    {
        public static void UseMigrations(this IApplicationBuilder applicationBuilder)
        {
            try
            {
                using var serviceScope = applicationBuilder
                    .ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();

                serviceScope.ServiceProvider
                    .GetService<ApplicationDbContext>()
                    .Database
                    .Migrate();

                Console.Write("Migration done.");
            }
            catch (Exception ex)
            {
                //EAP.Shared.Utils.ManageExceptionContext(new Exception("Failed to migrate or seed database" + ex));
                Console.Write($"Migration WRONG : {ex.Message}");
            }
        }
    }
}
