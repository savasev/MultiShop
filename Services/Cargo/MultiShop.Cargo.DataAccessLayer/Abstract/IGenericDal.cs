namespace MultiShop.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    Task InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);

    T GetByIdAsync(int id);

    Task<List<T>> GetAllAsync();
}
