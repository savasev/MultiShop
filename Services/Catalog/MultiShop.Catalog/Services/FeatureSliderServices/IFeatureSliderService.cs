using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync(bool? status = null, bool? ascending = null);

    Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id);

    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);

    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);

    Task DeleteFeatureSliderAsync(string id);
}
