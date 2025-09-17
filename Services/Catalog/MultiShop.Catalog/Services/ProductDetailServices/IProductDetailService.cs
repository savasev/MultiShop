﻿using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();

    Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id);

    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

    Task DeleteProductDetailAsync(string id);
}
