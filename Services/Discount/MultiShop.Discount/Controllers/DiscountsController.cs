using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    #region Fields

    private readonly IDiscountService _discountService;

    #endregion

    #region Ctor

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetCouponList()
    {
        var coupons = await _discountService.GetAllCouponsAsync();

        return Ok(coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var coupon = await _discountService.GetCouponByIdAsync(id);

        return Ok(coupon);
    }

    [HttpPost]
    public async  Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
    {
        await _discountService.CreateCouponAsync(createCouponDto);

        return Ok("Kupon başarıyla oluşturuldu.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
    {
        await _discountService.UpdateCouponAsync(updateCouponDto);

        return Ok("Kupon başarıyla güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await _discountService.DeleteCouponAsync(id);

        return Ok("Kupon başarıyla silindi.");
    }

    #endregion
}
