using FoodDelivery.Domain;

namespace FoodDelivery.Models;

public class ProductModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public static class ProductExtension
{
    public static ProductEntity ToProductEntity(this ProductModel model)
    {
        return new ProductEntity
        {
            Name = model.Name,
            Price = model.Price,
            Amount = model.Amount
        };
    }
    
    public static ProductModel ToProductModel(this ProductEntity entity)
    {
        return new ProductModel
        {
            Name = entity.Name,
            Price = entity.Price,
            Amount = entity.Amount
        };
    }
}