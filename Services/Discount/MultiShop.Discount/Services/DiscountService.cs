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

    public async Task DeleteCouponAsync(int couponId)
    {
        var query = "DELETE FROM Coupons WHERE CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId", couponId);

        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        var query = "SELECT * FROM Coupons";

        using (var connection = _dapperContext.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIdCouponDto> GetCouponByIdAsync(int couponId)
    {
        var query = "SELECT * FROM Coupons WHERE CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);

        using (var connection = _dapperContext.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        var query = "UPDATE Coupons SET Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate WHERE CouponId=@couponId";

        var parameters = new DynamicParameters();
        parameters.Add("@couponId", updateCouponDto.CouponId);
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);

        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    #endregion
}
