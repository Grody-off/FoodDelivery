using FoodDelivery.Domain;

namespace FoodDelivery.Models;

public class UserModel
{
    public string Name { get; set; }
    public long AddressId { get; set; }
}

public static class UserExtension
{
    public static UserEntity ToUserEntity(this UserModel model)
    {
        return new UserEntity
        {
            Name = model.Name,
            AddressId = model.AddressId
        };
    }
    
    public static UserModel ToUserModel(this UserEntity entity)
    {
        return new UserModel
        {
            Name = entity.Name,
            AddressId = entity.AddressId
        };
    }
}