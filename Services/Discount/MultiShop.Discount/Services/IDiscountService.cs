﻿using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponsAsync();

    Task CreateCouponAsync(CreateCouponDto createCouponDto);

    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);

    Task DeleteCouponAsync(int couponId);

    Task<GetByIdCouponDto> GetCouponByIdAsync(int couponId);
}
