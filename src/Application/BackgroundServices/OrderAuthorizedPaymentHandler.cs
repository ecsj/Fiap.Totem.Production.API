using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Domain.Responses;
using System.Diagnostics.CodeAnalysis;

namespace Application.BackgroundServices;

[ExcludeFromCodeCoverage]

public class OrderAuthorizedPaymentHandler : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrderAuthorizedPaymentHandler> _logger;
    private readonly IMessageQueueService _messageQueueService;

    public OrderAuthorizedPaymentHandler(IServiceProvider serviceProvider, ILogger<OrderAuthorizedPaymentHandler> logger, IMessageQueueService messageQueueService)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _messageQueueService = messageQueueService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Waiting for Orders Pending");

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            await _messageQueueService.ConsumeMessages("Totem.Order.AuthorizedPayment", async (message) =>
            {
                var order = JsonSerializer.Deserialize<OrderResponse>(message);

                using var scope = _serviceProvider.CreateScope();

                var orderService = scope.ServiceProvider.GetRequiredService<IProductionService>();

                await orderService.ReceivedOrder(order);

                _logger.LogInformation($"Message received: {order}");
            });

            await Task.Delay(1000, stoppingToken);

        }
    }
}