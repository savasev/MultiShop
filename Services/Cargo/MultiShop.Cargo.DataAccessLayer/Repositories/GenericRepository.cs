using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    #region Fields

    private readonly CargoContext _context;

    #endregion

    #region Ctor

    public GenericRepository(CargoContext cargoContext)
    {
        _context = cargoContext;
    }

    #endregion

    #region Methods

    public async Task DeleteAsync(int id)
    {
        var value = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(value);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    #endregion
}
