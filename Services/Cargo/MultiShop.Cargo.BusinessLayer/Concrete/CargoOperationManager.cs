using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    #region Fields

    private readonly ICargoOperationDal _cargoOperationDal;

    #endregion

    #region Ctor

    public CargoOperationManager(ICargoOperationDal cargoOperationDal)
    {
        _cargoOperationDal = cargoOperationDal;
    }

    #endregion

    #region Methods

    public async Task DeleteAsync(int id)
    {
        await _cargoOperationDal.DeleteAsync(id);
    }

    public async Task<List<CargoOperation>> GetAllAsync()
    {
        return await _cargoOperationDal.GetAllAsync();
    }

    public async Task<CargoOperation> GetByIdAsync(int id)
    {
        return await _cargoOperationDal.GetByIdAsync(id);
    }

    public async Task InsertAsync(CargoOperation entity)
    {
        await _cargoOperationDal.InsertAsync(entity);
    }

    public async Task UpdateAsync(CargoOperation entity)
    {
        await _cargoOperationDal.UpdateAsync(entity);
    }

    #endregion
}
