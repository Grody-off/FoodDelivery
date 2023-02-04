using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Domain;

public class OrderEntity : BaseEntity
{
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string Commentary { get; set; }
    public decimal TotalPrice { get; set; }
    
    
    [ForeignKey("UserId")]
    public UserEntity User { get; set; }
    [ForeignKey("AddressId")]
    public AddressEntity Address { get; set; }
}