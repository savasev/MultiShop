using MultiShop.Catalog.DTOs.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();

    Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id);

    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);

    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);

    Task DeleteFeatureSliderAsync(string id);
}
