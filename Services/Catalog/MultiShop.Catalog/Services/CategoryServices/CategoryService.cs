using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<Category> _categoryCollection;

    #endregion

    #region Ctor

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);

        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultCategoryDto>>(categories);
    }

    public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
    {
        var category = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdCategoryDto>(category);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);

        await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, category);
    }

    #endregion
}
