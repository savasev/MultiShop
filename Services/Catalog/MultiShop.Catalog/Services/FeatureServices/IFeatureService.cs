using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();

    Task<GetByIdFeatureDto> GetFeatureByIdAsync(string id);

    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);

    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);

    Task DeleteFeatureAsync(string id);
}
