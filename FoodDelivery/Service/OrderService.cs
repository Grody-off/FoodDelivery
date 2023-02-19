using System.Linq.Expressions;
using FoodDelivery.Domain;
using FoodDelivery.Repository;
using FoodDelivery.Service.Interfaces;

namespace FoodDelivery.Service;

public class OrderService : IOrderService
{
    private readonly IRepository<OrderEntity> _productRepository;
    private readonly INotificationService _notificationService;

    public OrderService(IRepository<OrderEntity> productRepository, INotificationService notificationService)
    {
        _productRepository = productRepository;
        _notificationService = notificationService;
    }
    
    public async ValueTask<OrderEntity?> GetById(long id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<OrderEntity> FirstOrDefault(Expression<Func<OrderEntity, bool>> predicate)
    {
        return await _productRepository.FirstOrDefault(predicate);
    }

    public async Task Add(OrderEntity entity)
    {
        await _productRepository.Add(entity);
        await _notificationService.SendToQueue($"{entity.Id}");
    }

    public async Task Update(OrderEntity entity)
    {
        await _productRepository.Update(entity);
    }

    public async Task Remove(OrderEntity entity)
    {
        await _productRepository.Remove(entity);
    }

    public async Task<IQueryable<OrderEntity>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<IQueryable<OrderEntity>> GetWhere(Expression<Func<OrderEntity, bool>> predicate)
    {
        return await _productRepository.GetWhere(predicate);
    }
}