using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImageCollection;

    #endregion

    #region Ctor

    public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(createProductImageDto);

        await _productImageCollection.InsertOneAsync(productImage);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
    {
        var productImages = await _productImageCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultProductImageDto>>(productImages);
    }

    public async Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id)
    {
        var productImage = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductImageDto>(productImage);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(updateProductImageDto);

        await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, productImage);
    }

    #endregion
}
