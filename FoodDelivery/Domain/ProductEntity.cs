namespace FoodDelivery.Domain;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}