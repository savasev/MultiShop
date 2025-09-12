using AutoMapper;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
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
    }
}
