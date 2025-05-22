using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;

    #endregion

    #region Ctor

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);

        await _productCollection.InsertOneAsync(product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductId == id);
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
    {
        var product = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdProductDto>(product);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = _mapper.Map<Product>(updateProductDto);

        await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, product);
    }

    #endregion
}
