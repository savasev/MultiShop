using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<Brand> _brandCollection;

    #endregion

    #region Ctor

    public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        var brand = _mapper.Map<Brand>(createBrandDto);

        await _brandCollection.InsertOneAsync(brand);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
    {
        var brands = await _brandCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultBrandDto>>(brands);
    }

    public async Task<GetByIdBrandDto> GetBrandByIdAsync(string id)
    {
        var brand = await _brandCollection.Find(x => x.BrandId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdBrandDto>(brand);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        var brand = _mapper.Map<Brand>(updateBrandDto);

        await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, brand);
    }

    #endregion
}
