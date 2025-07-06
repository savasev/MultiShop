using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    #region Fields

    private readonly ICargoDetailDal _cargoDetailDal;

    #endregion

    #region Ctor

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    #endregion

    #region Methods

    public async Task DeleteAsync(int id)
    {
        await _cargoDetailDal.DeleteAsync(id);
    }

    public async Task<List<CargoDetail>> GetAllAsync()
    {
        return await _cargoDetailDal.GetAllAsync();
    }

    public async Task<CargoDetail> GetByIdAsync(int id)
    {
        return await _cargoDetailDal.GetByIdAsync(id);
    }

    public async Task InsertAsync(CargoDetail entity)
    {
        await _cargoDetailDal.InsertAsync(entity);
    }

    public async Task UpdateAsync(CargoDetail entity)
    {
        await _cargoDetailDal.UpdateAsync(entity);
    }

    #endregion
}
