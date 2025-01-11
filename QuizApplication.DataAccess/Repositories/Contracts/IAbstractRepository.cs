namespace QuizApplication.DataAccess.Repositories.Contracts;

public interface IAbstractRepository<T> where T : class
{
    Task<T?> GetSingleAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> CheckIfRecordExists(int id);
}