namespace MultiShop.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    Task InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);

    Task<T> GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();
}
