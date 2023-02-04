using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Domain;

public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public long AddressId { get; set; }
    
    [ForeignKey("AddressId")]
    public AddressEntity AddressEntity { get; set; }
}