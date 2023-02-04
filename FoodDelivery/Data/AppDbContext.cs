using FoodDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    
}