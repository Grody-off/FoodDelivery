using FoodDelivery.Domain;

namespace FoodDelivery.Models;

public class OrderItemModel
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Amount { get; set; }
}

public static class OrderItemExtension
{
    public static List<OrderItemEntity> ToOrderItemEntity(this List<OrderItemModel> model)
    {
        var items = new List<OrderItemEntity>();
        model.ForEach(itemModel => items.Add(new OrderItemEntity
        {
            OrderId = itemModel.OrderId,
            ProductId = itemModel.ProductId,
            Amount = itemModel.Amount,
        }));
        return items;
    }

    public static List<OrderItemModel> ToOrderItemModel(this List<OrderItemEntity> entity)
    {
        var items = new List<OrderItemModel>();
        entity.ForEach(itemModel => items.Add(new OrderItemModel
        {
            OrderId = itemModel.OrderId,
            ProductId = itemModel.ProductId,
            Amount = itemModel.Amount,
        }));
        return items;
    }
}