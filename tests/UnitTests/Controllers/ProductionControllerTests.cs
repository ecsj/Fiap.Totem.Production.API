using System.Threading.Tasks;
using API.Controllers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests;

public class ProductionControllerTests
{
    [Fact]
    public async Task GetOrders_ReturnsOkResult()
    {
        // Arrange
        var productionServiceMock = new Mock<IProductionService>();
        var controller = new ProductionController(productionServiceMock.Object);

        // Act
        var result = await controller.GetOrders();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}