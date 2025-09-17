using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

    #endregion

    #region Ctor

    public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        var featureSlider = _mapper.Map<FeatureSlider>(createFeatureSliderDto);

        await _featureSliderCollection.InsertOneAsync(featureSlider);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync(bool? status = null, bool? ascending = null)
    {
        var filter = Builders<FeatureSlider>.Filter.Empty;

        if (status.HasValue)
            filter = Builders<FeatureSlider>.Filter.Eq(x => x.Status, status.Value);

        var query = _featureSliderCollection.Find(filter);

        if (ascending.HasValue)
        {
            query = ascending.Value
                ? query.Sort(Builders<FeatureSlider>.Sort.Ascending(x => x.DisplayOrder))
                : query.Sort(Builders<FeatureSlider>.Sort.Descending(x => x.DisplayOrder));
        }

        var featureSliders = await query.ToListAsync();

        return _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
    }

    public async Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
    {
        var featureSlider = await _featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdFeatureSliderDto>(featureSlider);
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        var featureSlider = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);

        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, featureSlider);
    }

    #endregion
}
