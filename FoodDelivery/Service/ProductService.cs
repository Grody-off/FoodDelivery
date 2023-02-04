using System.Linq.Expressions;
using FoodDelivery.Domain;
using FoodDelivery.Repository;
using FoodDelivery.Service.Interfaces;

namespace FoodDelivery.Service;

public class ProductService : IProductService
{
    private readonly IRepository<ProductEntity> _productRepository;

    public ProductService(IRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async ValueTask<ProductEntity?> GetById(long id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<ProductEntity> FirstOrDefault(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _productRepository.FirstOrDefault(predicate);
    }

    public async Task Add(ProductEntity entity)
    {
        await _productRepository.Add(entity);
    }

    public async Task Update(ProductEntity entity)
    {
        await _productRepository.Update(entity);
    }

    public async Task Remove(ProductEntity entity)
    {
        await _productRepository.Remove(entity);
    }

    public async Task<IQueryable<ProductEntity>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<IQueryable<ProductEntity>> GetWhere(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _productRepository.GetWhere(predicate);
    }
}