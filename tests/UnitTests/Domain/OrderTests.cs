using Domain.Entity;
using Domain.Responses;
using Xunit;

namespace UnitTests;

public class OrderTests
{
    [Fact]
    public void Order_ConstructorWithResponse_SetsPropertiesCorrectly()
    {
        // Arrange
        var response = new OrderResponse
        {
            Id = Guid.NewGuid(),
            Status = OrderStatus.Pending,
            OrderDate = DateTime.Now
        };

        // Act
        var order = new Order(response);

        // Assert
        Assert.NotNull(order.Id);
        Assert.Equal(response.Id, order.OrderId);
        Assert.Equal(response.Status, order.Status);
        Assert.Equal(response.OrderDate, order.OrderTime);
    }
}
