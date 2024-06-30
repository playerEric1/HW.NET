using ApplicationCore.Interfaces;
using EShopAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T:class
{
    private readonly EShopDBContext dbContext;
    public BaseRepositoryAsync(EShopDBContext db)
    {
        dbContext = db;
    }

    public async Task<T> GetAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<int> InsertAsync(T entity)
    {
        dbContext.Set<T>().AddAsync(entity);
        return await dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        dbContext.Remove(result);
        return await dbContext.SaveChangesAsync();
    }
}