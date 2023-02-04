using System.Linq.Expressions;
using FoodDelivery.Domain;
using FoodDelivery.Repository;
using FoodDelivery.Service.Interfaces;

namespace FoodDelivery.Service;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _userRepository;

    public UserService(IRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async ValueTask<UserEntity?> GetById(long id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<UserEntity> FirstOrDefault(Expression<Func<UserEntity, bool>> predicate)
    {
        return await _userRepository.FirstOrDefault(predicate);
    }

    public async Task Add(UserEntity entity)
    {
        await _userRepository.Add(entity);
    }

    public async Task Update(UserEntity entity)
    {
        await _userRepository.Update(entity);
    }

    public async Task Remove(UserEntity entity)
    {
        await _userRepository.Remove(entity);
    }

    public async Task<IQueryable<UserEntity>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<IQueryable<UserEntity>> GetWhere(Expression<Func<UserEntity, bool>> predicate)
    {
        return await _userRepository.GetWhere(predicate);
    }
}