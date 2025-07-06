using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    #region Fields

    private readonly ICargoCompanyDal _cargoCompanyDal;

    #endregion

    #region Ctor

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    #endregion

    #region Methods

    public async Task DeleteAsync(int id)
    {
        await _cargoCompanyDal.DeleteAsync(id);
    }

    public async Task<List<CargoCompany>> GetAllAsync()
    {
        return await _cargoCompanyDal.GetAllAsync();
    }

    public async Task<CargoCompany> GetByIdAsync(int id)
    {
        return await _cargoCompanyDal.GetByIdAsync(id);
    }

    public async Task InsertAsync(CargoCompany entity)
    {
        await InsertAsync(entity);
    }

    public async Task UpdateAsync(CargoCompany entity)
    {
        await _cargoCompanyDal.UpdateAsync(entity);
    }

    #endregion
}
