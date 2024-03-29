using Application.Interfaces;
using Domain.Repositories;
using Infra.Data.Repositories;
using Infra.MessageQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Infra;

[ExcludeFromCodeCoverage]

public class Dependencies
{
    public static IServiceCollection ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<IMessageQueueService, RabbitMQService>();

        services.AddSingleton<IMongoClient>(sp =>
        {
            return new MongoClient(configuration.GetConnectionString("mongoDb"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();


        return services;
    }
}
