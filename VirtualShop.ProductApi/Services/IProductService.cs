﻿using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task AddProduct(ProductDTO productDTO);
    Task UpdateProduct(ProductDTO productDTO);
    Task RemoveProduct(int id);
}

