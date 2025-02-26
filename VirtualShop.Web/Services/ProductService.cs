using System.Text.Json;
using Microsoft.Extensions.Http;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services;
using VirtualShop.Web.Models;

namespace VirtualShop.Web.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "/api/products/";
    private readonly JsonSerializerOptions _options;
    private ProductViewModel productVM;
    private IEnumerable<ProductViewModel> productsVM;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public Task<IEnumerable<ProductDTO>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveProduct(int id)
    {
        throw new NotImplementedException();
    }
}
