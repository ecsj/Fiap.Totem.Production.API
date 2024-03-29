using Domain.Entity;
using Domain.Responses;

namespace Application.Interfaces;

public interface IProductionService
{
    Task<List<Order>> GetOrders();
    Task ReceivedOrder(OrderResponse order);
}