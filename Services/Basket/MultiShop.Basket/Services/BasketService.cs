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
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasketAsync(string userId)
    {
        var basketTotal = await _redisService.GetDb().StringGetAsync(userId);
        if (basketTotal.HasValue && !basketTotal.IsNull)
            return JsonSerializer.Deserialize<BasketTotalDto>(basketTotal);

        return null;
    }

    public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }

    #endregion
}
