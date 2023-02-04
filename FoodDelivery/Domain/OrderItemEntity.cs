using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Domain;

public class OrderItemEntity : BaseEntity
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey("ProductId")]
    public ProductEntity Product { get; set; }
    
    [ForeignKey("OrderId")]
    public OrderEntity OrderEntity { get; set; }
}