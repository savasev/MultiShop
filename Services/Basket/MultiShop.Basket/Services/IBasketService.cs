using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasketAsync(string userId);

    Task SaveBasketAsync(BasketTotalDto basket);

    Task DeleteBasketAsync(string userId);
}
