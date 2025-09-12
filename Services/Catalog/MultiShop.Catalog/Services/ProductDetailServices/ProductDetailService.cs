using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;

    #endregion

    #region Ctor

    public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);

        await _productDetailCollection.InsertOneAsync(productDetail);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
    {
        var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id)
    {
        var productDetail = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductDetailDto>(productDetail);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);

        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, productDetail);
    }

    #endregion
}
