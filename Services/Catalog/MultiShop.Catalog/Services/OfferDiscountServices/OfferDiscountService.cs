using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;

    #endregion

    #region Ctor

    public OfferDiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _offerDiscountCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
        var offerDiscount = _mapper.Map<OfferDiscount>(createOfferDiscountDto);

        await _offerDiscountCollection.InsertOneAsync(offerDiscount);
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
    {
        var offerDiscounts = await _offerDiscountCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultOfferDiscountDto>>(offerDiscounts);
    }

    public async Task<GetByIdOfferDiscountDto> GetOfferDiscountByIdAsync(string id)
    {
        var offerDiscount = await _offerDiscountCollection.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdOfferDiscountDto>(offerDiscount);
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        var offerDiscount = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);

        await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, offerDiscount);
    }

    #endregion
}
