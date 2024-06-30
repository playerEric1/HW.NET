namespace ApplicationCore.Interfaces;

public interface IRepositoryAsync<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}