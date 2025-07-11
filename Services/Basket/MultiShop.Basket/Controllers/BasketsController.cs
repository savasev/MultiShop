using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    #region Fields

    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    #endregion

    #region Ctor

    public BasketsController(IBasketService basketService,
        ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetBasketDetail()
    {
        var values = await _basketService.GetBasketAsync(_loginService.GetUserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;

        await _basketService.SaveBasketAsync(basketTotalDto);

        return Ok("Sepetteki değişiklikler kaydedildi.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasketAsync(_loginService.GetUserId);

        return Ok("Sepet başarıyla silindi.");
    }

    #endregion
}
