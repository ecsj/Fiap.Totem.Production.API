using Domain.Base;
using Domain.Entity;

namespace Domain.Responses;
public class OrderResponse
{
    public Guid Id { get; set ;}
    public Guid? ClientId { get; set ;}
    public int OrderCode { get; set; }
    public DateTime OrderDate { get; set ;}
    public OrderStatus Status { get; set ;}
    public string OrderStatusDescription => Status.GetDescription();
    public TimeSpan WaitingTime => DateTime.UtcNow - OrderDate;
    public decimal TotalPrice { get; set; }
}