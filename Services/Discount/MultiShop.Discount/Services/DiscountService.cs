using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    #region Fields

    private readonly DapperContext _dapperContext;

    #endregion

    #region Ctor

    public DiscountService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    #endregion

    #region Methods

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        var query = "INSERT INTO Coupons(Code, Rate, IsActive, ValidDate) VALUES (@code, @rate, @isActive, @validDate)";

        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);

        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
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
