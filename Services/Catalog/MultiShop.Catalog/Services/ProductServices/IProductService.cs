﻿using MultiShop.Catalog.DTOs.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductsAsync();

    Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();

    Task<GetByIdProductDto> GetProductByIdAsync(string id);

    Task CreateProductAsync(CreateProductDto createProductDto);

    Task UpdateProductAsync(UpdateProductDto updateProductDto);

    Task DeleteProductAsync(string id);
}
