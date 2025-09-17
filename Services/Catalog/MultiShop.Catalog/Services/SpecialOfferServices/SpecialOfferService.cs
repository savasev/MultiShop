using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

    #endregion

    #region Ctor

    public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
    }

    #endregion

    #region Methods

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        var specialOffer = _mapper.Map<SpecialOffer>(createSpecialOfferDto);

        await _specialOfferCollection.InsertOneAsync(specialOffer);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
    {
        var specialOffers = await _specialOfferCollection.Find(x => true).ToListAsync();

        return _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
    }

    public async Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
    {
        var specialOffer = await _specialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();

        return _mapper.Map<GetByIdSpecialOfferDto>(specialOffer);
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        var specialOffer = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);

        await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, specialOffer);
    }

    #endregion
}
