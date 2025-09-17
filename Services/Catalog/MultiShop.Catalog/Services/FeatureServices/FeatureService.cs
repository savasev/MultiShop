using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<Feature> _featureCollection;

    #endregion

    #region Ctor

    public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        var feature = _mapper.Map<Feature>(createFeatureDto);

        await _featureCollection.InsertOneAsync(feature);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
    {
        var features = await _featureCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultFeatureDto>>(features);
    }

    public async Task<GetByIdFeatureDto> GetFeatureByIdAsync(string id)
    {
        var feature = await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdFeatureDto>(feature);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        var feature = _mapper.Map<Feature>(updateFeatureDto);

        await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, feature);
    }

    #endregion
}
