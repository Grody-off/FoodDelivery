using FoodDelivery.Domain;

namespace FoodDelivery.Models;

public class AddressModel
{
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
}

public static class AddressExtension
{
    public static AddressEntity ToAddressEntity(this AddressModel model)
    {
        return new AddressEntity
        {
            City = model.City,
            Street = model.Street,
            House = model.House,
        };
    }
    
    public static AddressModel ToAddressModel(this AddressEntity entity)
    {
        return new AddressModel
        {
            City = entity.City,
            Street = entity.City,
            House = entity.City,
        };
    }
}