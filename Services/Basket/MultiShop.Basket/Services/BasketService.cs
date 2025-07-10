using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services;

public class BasketService : IBasketService
{
    #region Fields

    private readonly RedisService _redisService;

    #endregion

    #region Ctor

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    #endregion

    #region Methods

    public async Task DeleteBasketAsync(string userId)
    {
        var status = await _redisService.GetDb().KeyDeleteAsync(userId);


    }

    public async Task<BasketTotalDto> GetBasketAsync(string userId)
    {
        var basketTotal = await _redisService.GetDb().StringGetAsync(userId);

        return JsonSerializer.Deserialize<BasketTotalDto>(basketTotal);
    }

    public Task<bool> SaveBasketAsync(BasketTotalDto basket)
    {
        throw new NotImplementedException();
    }

    #endregion
}
