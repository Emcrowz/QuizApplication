using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.DataAccess.Repositories.Base;

public class AbstractRepository<T>(QuizDbContext context) : IAbstractRepository<T> where T : class
{
    public async Task<T?> GetSingleAsync(int id)
    {
        var result = await context.Set<T>().FindAsync(id);
        if (result is null)
        {
            return null;
        }

        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await context.Set<T>().ToListAsync();
        return result;
    }

    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetSingleAsync(id);
        if (entity is null)
        {
            ArgumentNullException.ThrowIfNull(entity);
        }

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> CheckIfRecordExists(int id)
    {
        var entity = await GetSingleAsync(id);
        return entity != null;
    }
}