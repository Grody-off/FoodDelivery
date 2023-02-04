using FoodDelivery.Domain;

namespace FoodDelivery.Models;

public class OrderModel
{
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string Commentary { get; set; }
    public decimal TotalPrice { get; set; }
}

public static class OrderExtension
{
    public static OrderEntity ToOrderEntity(this OrderModel model)
    {
        return new OrderEntity
        {
            UserId = model.UserId,
            AddressId = model.AddressId,
            Commentary = model.Commentary,
            TotalPrice = model.TotalPrice,
        };
    }
    
    public static OrderModel ToOrderModel(this OrderEntity entity)
    {
        return new OrderModel
        {
            UserId = entity.UserId,
            AddressId = entity.AddressId,
            Commentary = entity.Commentary,
            TotalPrice = entity.TotalPrice,
        };
    }
}