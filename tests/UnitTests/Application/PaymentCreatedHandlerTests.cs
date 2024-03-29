using Application.BackgroundServices;
using Application.Interfaces;
using Domain.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System.Reflection.Metadata;
using System.Text.Json;
using Xunit;

namespace UnitTests;
public class PaymentCreatedHandlerTests
{
    private readonly Mock<IServiceProvider> _serviceProviderMock;
    private readonly Mock<ILogger<OrderAuthorizedPaymentHandler>> _loggerMock;
    private readonly Mock<IMessageQueueService> _messageQueueServiceMock;

    public PaymentCreatedHandlerTests()
    {
        _serviceProviderMock = new Mock<IServiceProvider>();
        _loggerMock = new Mock<ILogger<OrderAuthorizedPaymentHandler>>();
        _messageQueueServiceMock = new Mock<IMessageQueueService>();
    }

    [Fact]
    public void Constructor_ShouldInitializeDependencies()
    {
        // Arrange

        // Act
        var handler = new OrderAuthorizedPaymentHandler(
            _serviceProviderMock.Object,
            _loggerMock.Object,
            _messageQueueServiceMock.Object
        );

        // Assert
        Assert.NotNull(handler);
    }
}