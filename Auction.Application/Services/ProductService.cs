using Auction.Application.Dtos;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        _logger.LogInformation("getting all the products.");
        var products = await _productRepository.GetAllAsync();
        var productsDtos = products.Select(ProductDto.FromEntity);
        
        return productsDtos!;
    }

    public async Task<ProductDto?> GetProductById(int id)
    {
        _logger.LogInformation($"getting product by id: {id}");
        var product = await _productRepository.GetByIdAsync(id);
        var productDto = ProductDto.FromEntity(product);

        return productDto;
    }
}
