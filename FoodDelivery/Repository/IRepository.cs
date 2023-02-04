using System.Linq.Expressions;
using FoodDelivery.Domain;

namespace FoodDelivery.Repository;

public interface IRepository<T> where T : BaseEntity 
{
    ValueTask<T?> GetById(long id);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);

    Task Add(T entity);
    Task Update(T entity);
    Task Remove(T entity);

    Task<IQueryable<T>> GetAll();
    Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> predicate);
}