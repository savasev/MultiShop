using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers;

public class SpecialOffersController : BaseApiController
{
    #region Fields

    private readonly ISpecialOfferService _specialOfferService;

    #endregion

    #region Ctor

    public SpecialOffersController(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetSpecialOfferList()
    {
        var specialOffers = await _specialOfferService.GetAllSpecialOffersAsync();

        return Ok(specialOffers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOfferById(string id)
    {
        var specialOffer = await _specialOfferService.GetSpecialOfferByIdAsync(id);

        return Ok(specialOffer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

        return Ok("Özel teklif başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

        return Ok("Özel teklif başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);

        return Ok("Özel teklif başarıyla silindi.");
    }

    #endregion
}
