using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductionController : ControllerBase
{
    private readonly IProductionService _productionService;

    public ProductionController(IProductionService productionService)
    {
        _productionService = productionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var result = await _productionService.GetOrders();

        return Ok(result);
    }
}