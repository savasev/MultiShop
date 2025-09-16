using AutoMapper;
using MultiShop.Catalog.DTOs.BrandDtos;
using MultiShop.Catalog.DTOs.CategoryDtos;
using MultiShop.Catalog.DTOs.FeatureDtos;
using MultiShop.Catalog.DTOs.FeatureSliderDtos;
using MultiShop.Catalog.DTOs.OfferDiscountDtos;
using MultiShop.Catalog.DTOs.ProductDetailDtos;
using MultiShop.Catalog.DTOs.ProductDtos;
using MultiShop.Catalog.DTOs.ProductImageDtos;
using MultiShop.Catalog.DTOs.SiteInfoDtos;
using MultiShop.Catalog.DTOs.SpecialOfferDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategoryDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

        CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

        CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

        CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
        CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
        CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
        CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();

        CreateMap<Brand, ResultBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

        CreateMap<SiteInfo, ResultSiteInfoDto>().ReverseMap();
        CreateMap<SiteInfo, CreateSiteInfoDto>().ReverseMap();
        CreateMap<SiteInfo, UpdateSiteInfoDto>().ReverseMap();
        CreateMap<SiteInfo, GetByIdSiteInfoDto>().ReverseMap();
    }
}
