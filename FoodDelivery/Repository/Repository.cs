using System.Linq.Expressions;
using FoodDelivery.Data;
using FoodDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public ValueTask<T?> GetById(long id)
    {
        return _context.Set<T>().FindAsync(id);
    }
    public Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return _context.SaveChangesAsync();
    }

    public Task Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).AsNoTracking();
    }
}