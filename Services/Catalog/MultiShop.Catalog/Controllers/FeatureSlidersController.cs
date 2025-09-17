﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers;

public class FeatureSlidersController : BaseApiController
{
    #region Fields

    private readonly IFeatureSliderService _featureSliderService;

    #endregion

    #region Ctor

    public FeatureSlidersController(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetFeatureSliderList([FromQuery] FeatureSliderQueryDto featureSliderQueryDto)
    {
        var featureSliders = await _featureSliderService.GetAllFeatureSlidersAsync(status: featureSliderQueryDto.Status,
            ascending: featureSliderQueryDto.Ascending);

        return Ok(featureSliders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureSliderById(string id)
    {
        var featureSlider = await _featureSliderService.GetFeatureSliderByIdAsync(id);

        return Ok(featureSlider);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

        return Ok("Slider başarıyla eklendi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

        return Ok("Slider başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        await _featureSliderService.DeleteFeatureSliderAsync(id);

        return Ok("Slider başarıyla silindi.");
    }

    #endregion
}
