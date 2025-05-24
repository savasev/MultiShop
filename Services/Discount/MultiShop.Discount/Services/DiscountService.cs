using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    #region Methods

    public Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCouponAsync(int couponId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCouponDto> GetCouponByIdAsync(int couponId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        throw new NotImplementedException();
    }

    #endregion
}
