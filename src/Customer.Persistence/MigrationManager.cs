using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
namespace Customer.Persistence
{
    [ExcludeFromCodeCoverage]
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var CustomerContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
            var environment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomerDbContext>>();
            try
            {
                logger.LogInformation("DB Migration Started");
                CustomerContext.Database.Migrate();
                logger.LogInformation("DB Migration Completed");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }

            return host;
        }
    }
}