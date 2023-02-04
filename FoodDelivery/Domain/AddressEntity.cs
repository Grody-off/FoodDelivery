namespace FoodDelivery.Domain;

public class AddressEntity : BaseEntity
{
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
}