using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.SiteInfoDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SiteInfoServices;

public class SiteInfoService : ISiteInfoService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<SiteInfo> _siteInfoCollection;

    #endregion

    #region Ctor

    public SiteInfoService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _siteInfoCollection = database.GetCollection<SiteInfo>(databaseSettings.SiteInfoCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateSiteInfoAsync(CreateSiteInfoDto createSiteInfoDto)
    {
        var siteInfo = _mapper.Map<SiteInfo>(createSiteInfoDto);

        await _siteInfoCollection.InsertOneAsync(siteInfo);
    }

    public async Task DeleteSiteInfoAsync(string id)
    {
        await _siteInfoCollection.DeleteOneAsync(x => x.SiteInfoId == id);
    }

    public async Task<List<ResultSiteInfoDto>> GetAllSiteInfosAsync()
    {
        var siteInfos = await _siteInfoCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultSiteInfoDto>>(siteInfos);
    }

    public async Task<GetByIdSiteInfoDto> GetSiteInfoByIdAsync(string id)
    {
        var siteInfo = await _siteInfoCollection.Find(x => x.SiteInfoId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdSiteInfoDto>(siteInfo);
    }

    public async Task<ResultSiteInfoDto> GetSiteInfoByCategoryAsync(string category)
    {
        var siteInfo = await _siteInfoCollection.Find(x => x.Category == category)
            .SortByDescending(x => x.CreatedOnUtc)
            .FirstOrDefaultAsync();

        return _mapper.Map<ResultSiteInfoDto>(siteInfo);
    }

    public async Task UpdateSiteInfoAsync(UpdateSiteInfoDto updateSiteInfoDto)
    {
        var existingSiteInfo = await _siteInfoCollection.Find(x => x.SiteInfoId == updateSiteInfoDto.SiteInfoId)
            .FirstOrDefaultAsync();

        if (existingSiteInfo == null)
            throw new ArgumentNullException(nameof(existingSiteInfo));

        var siteInfo = _mapper.Map<SiteInfo>(updateSiteInfoDto);

        siteInfo.CreatedOnUtc = existingSiteInfo.CreatedOnUtc;

        await _siteInfoCollection.FindOneAndReplaceAsync(x => x.SiteInfoId == updateSiteInfoDto.SiteInfoId, siteInfo);
    }

    #endregion
}
