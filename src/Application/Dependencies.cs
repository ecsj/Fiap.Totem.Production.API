using Application.Interfaces;
using Application.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Application.BackgroundServices;

namespace Application;

[ExcludeFromCodeCoverage]
public class Dependencies
{
    public static IServiceCollection ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {        
        services.AddScoped<IProductionService, ProductionService>();
        services.AddHostedService<OrderAuthorizedPaymentHandler>();

        return services;
    }
}