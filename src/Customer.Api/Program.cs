using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Customer.Api.Extension;
using Customer.Persistence;
using Serilog;

namespace Customer.Api
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static int Main(string[] args)
        {
            // This logger added to get logs during start up only to log any error during start up
            // Later logger configured by AddApiLogger() method will be used in the app 
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
            Log.Information("Customer API Starting...");

            try
            {
                CreateHostBuilder(args).Build()
                    .MigrateDatabase()
                    .Run();
                Log.Information("Customer API Stopped...");
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occured during Customer API bootstrapping....");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddApiConfigServer(config.Build());
                })
                .AddApiLogger()
                .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });
        
    }
}