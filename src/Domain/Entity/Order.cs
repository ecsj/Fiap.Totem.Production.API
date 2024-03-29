using Domain.Responses;

namespace Domain.Entity;

public class Order : Base.Entity
{
    public Guid OrderId { get; set; }
    public DateTime OrderTime { get; set; }
    public OrderStatus Status { get; set; }
    public int OrderCode { get; set; }

    public Order()
    {

    }

    public Order(OrderResponse response)
    {
        Id = Guid.NewGuid().ToString();
        OrderId = response.Id;
        Status = response.Status;
        OrderTime = response.OrderDate;
        OrderCode = response.OrderCode;
    }
}