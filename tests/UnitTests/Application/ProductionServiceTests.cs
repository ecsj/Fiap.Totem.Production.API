using Application.UseCases;
using Domain.Entity;
using Domain.Repositories;
using Domain.Responses;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System;


namespace UnitTests;

public class ProductionServiceTests
{
    private Mock<IOrderRepository> _orderRepositoryMock;
    private ProductionService _productionService;

    public ProductionServiceTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _productionService = new ProductionService(_orderRepositoryMock.Object);
    }

    [Fact]
    public async Task GetOrders_ShouldReturnListOfOrders()
    {
        // Arrange
        var expectedOrders = new List<Order> { new Order(), new Order(), new Order() };
        _orderRepositoryMock.Setup(repo => repo.Get()).ReturnsAsync(expectedOrders);

        // Act
        var result = await _productionService.GetOrders();

        // Assert
        Assert.Equal(expectedOrders, result);
    }


    // ...

    [Fact]
    public async Task ReceivedOrder_ShouldAddOrderToRepository()
    {
        // Arrange
        var orderResponse = new OrderResponse { Id = Guid.NewGuid(), Status = OrderStatus.Pending, OrderDate = DateTime.Now };

        // Act
        await _productionService.ReceivedOrder(orderResponse);

        // Assert
        _orderRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Order>(o => o.OrderId == orderResponse.Id)), Times.Once);
    }
}