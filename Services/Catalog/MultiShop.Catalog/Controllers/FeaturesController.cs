using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers;

public class FeaturesController : BaseApiController
{
    #region Fields

    private readonly IFeatureService _featureService;

    #endregion

    #region Ctor

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetFeatureList()
    {
        var features = await _featureService.GetAllFeaturesAsync();

        return Ok(features);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureById(string id)
    {
        var feature = await _featureService.GetFeatureByIdAsync(id);

        return Ok(feature);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _featureService.CreateFeatureAsync(createFeatureDto);

        return Ok("Özellik başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updateFeatureDto);

        return Ok("Özellik başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);

        return Ok("Özellik başarıyla silindi.");
    }

    #endregion
}
