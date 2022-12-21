using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Customer.Application.Tools;
using Customer.Domain.Repository;
using Customer.Persistence.Provider;
using Customer.Persistence.Provider.Contract;
using Customer.Persistence.Repository;


namespace Customer.Api.Extension
{
    [ExcludeFromCodeCoverage]
    internal static class ApiDependencyExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDomainDependency(configuration)
                           .AddPersistenceDependency(configuration)
                           .AddApplication(configuration);
        }

        private static IServiceCollection AddDomainDependency(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        private static IServiceCollection AddPersistenceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IBankRepository, BankRepository>()
                .AddScoped<IBankProvider, BankProvider>();
        }
    }
}