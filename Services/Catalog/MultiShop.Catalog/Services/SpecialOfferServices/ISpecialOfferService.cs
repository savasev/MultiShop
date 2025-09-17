using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();

    Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id);

    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);

    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);

    Task DeleteSpecialOfferAsync(string id);
}
