using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers;

public class OfferDiscountsController : BaseApiController
{
    #region Fields

    private readonly IOfferDiscountService _offerDiscountService;

    #endregion

    #region Ctor

    public OfferDiscountsController(IOfferDiscountService offerDiscountService)
    {
        _offerDiscountService = offerDiscountService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetOfferDiscountList()
    {
        var offerDiscounts = await _offerDiscountService.GetAllOfferDiscountsAsync();

        return Ok(offerDiscounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferDiscountById(string id)
    {
        var offerDiscount = await _offerDiscountService.GetOfferDiscountByIdAsync(id);

        return Ok(offerDiscount);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
        await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);

        return Ok("İndirim teklifi başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);

        return Ok("İndirim teklifi başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOfferDiscount(string id)
    {
        await _offerDiscountService.DeleteOfferDiscountAsync(id);

        return Ok("İndirim teklifi başarıyla silindi.");
    }

    #endregion
}
