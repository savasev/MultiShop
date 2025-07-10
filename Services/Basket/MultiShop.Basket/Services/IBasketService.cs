using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasketAsync(string userId);

    Task<bool> SaveBasketAsync(BasketTotalDto basket);

    Task DeleteBasketAsync(string userId);
}
