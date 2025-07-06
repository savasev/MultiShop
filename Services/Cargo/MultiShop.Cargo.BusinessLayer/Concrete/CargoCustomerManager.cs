using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCustomerManager : ICargoCustomerService
{
    #region Fields

    private readonly ICargoCustomerDal _cargoCustomerDal;

    #endregion

    #region Ctor

    public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
    {
        _cargoCustomerDal = cargoCustomerDal;
    }

    #endregion

    #region Methods

    public async Task DeleteAsync(int id)
    {
        await _cargoCustomerDal.DeleteAsync(id);
    }

    public async Task<List<CargoCustomer>> GetAllAsync()
    {
        return await _cargoCustomerDal.GetAllAsync();
    }

    public async Task<CargoCustomer> GetByIdAsync(int id)
    {
        return await _cargoCustomerDal.GetByIdAsync(id);
    }

    public async Task InsertAsync(CargoCustomer entity)
    {
        await _cargoCustomerDal.InsertAsync(entity);
    }

    public async Task UpdateAsync(CargoCustomer entity)
    {
        await _cargoCustomerDal.UpdateAsync(entity);
    }

    #endregion
}
