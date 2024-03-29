using Application.Interfaces;
using Domain.Entity;
using Domain.Repositories;
using Domain.Responses;

namespace Application.UseCases;

public class ProductionService : IProductionService
{

    private readonly IOrderRepository _orderRepository;

    public ProductionService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _orderRepository.Get();
    }

    public async Task ReceivedOrder(OrderResponse order)
    {
        try
        {
            await _orderRepository.AddAsync(new Order(order));

            Console.WriteLine("OrderResponse");
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}