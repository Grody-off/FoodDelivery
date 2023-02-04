using System.Linq.Expressions;
using FoodDelivery.Domain;
using FoodDelivery.Repository;
using FoodDelivery.Service.Interfaces;

namespace FoodDelivery.Service;

public class AddressService : IAddressService
{
    private readonly IRepository<AddressEntity> _productRepository;

    public AddressService(IRepository<AddressEntity> productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async ValueTask<AddressEntity?> GetById(long id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<AddressEntity> FirstOrDefault(Expression<Func<AddressEntity, bool>> predicate)
    {
        return await _productRepository.FirstOrDefault(predicate);
    }

    public async Task Add(AddressEntity entity)
    {
        await _productRepository.Add(entity);
    }

    public async Task Update(AddressEntity entity)
    {
        await _productRepository.Update(entity);
    }

    public async Task Remove(AddressEntity entity)
    {
        await _productRepository.Remove(entity);
    }

    public async Task<IQueryable<AddressEntity>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<IQueryable<AddressEntity>> GetWhere(Expression<Func<AddressEntity, bool>> predicate)
    {
        return await _productRepository.GetWhere(predicate);
    }
}