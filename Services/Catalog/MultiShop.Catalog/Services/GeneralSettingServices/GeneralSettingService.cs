using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.GeneralSettingDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.GeneralSettingServices;

public class GeneralSettingService : IGeneralSettingService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<GeneralSetting> _generalSettingCollection;

    #endregion

    #region Ctor

    public GeneralSettingService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _generalSettingCollection = database.GetCollection<GeneralSetting>(databaseSettings.GeneralSettingCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateGeneralSettingAsync(CreateGeneralSettingDto createGeneralSettingDto)
    {
        var generalSetting = _mapper.Map<GeneralSetting>(createGeneralSettingDto);

        await _generalSettingCollection.InsertOneAsync(generalSetting);
    }

    public async Task DeleteGeneralSettingAsync(string id)
    {
        await _generalSettingCollection.DeleteOneAsync(x => x.GeneralSettingId == id);
    }

    public async Task<List<ResultGeneralSettingDto>> GetAllGeneralSettingsAsync()
    {
        var generalSettings = await _generalSettingCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultGeneralSettingDto>>(generalSettings);
    }

    public async Task<GetByIdGeneralSettingDto> GetGeneralSettingByIdAsync(string id)
    {
        var generalSetting = await _generalSettingCollection.Find(x => x.GeneralSettingId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdGeneralSettingDto>(generalSetting);
    }

    public async Task UpdateGeneralSettingAsync(UpdateGeneralSettingDto updateGeneralSettingDto)
    {
        var generalSetting = _mapper.Map<GeneralSetting>(updateGeneralSettingDto);

        await _generalSettingCollection.FindOneAndReplaceAsync(x => x.GeneralSettingId == updateGeneralSettingDto.GeneralSettingId, generalSetting);
    }

    #endregion
}
