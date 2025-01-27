using Auction.Application.Dtos;
using Auction.Domain.Exceptions;
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

    public async Task<ProductDto> GetProductById(int id)
    {
        _logger.LogInformation("getting product by id: {ProductId}", id);

        var product = await _productRepository.GetByIdAsync(id) 
            ?? throw new NotFoundException($"Product with id: {id} couldn't be found.");

        var productDto = ProductDto.FromEntity(product);

        return productDto;
    }

    public async Task<int> CreateProduct(CreateProductDto createProductDto)
    {
        _logger.LogInformation("creating new product. {@CreatedProduct}", createProductDto);

        var product = CreateProductDto.ToProduct(createProductDto);
        int id = await _productRepository.CreateProduct(product!);

        return id;
    }

    public async Task UpdateProduct(int id, UpdateProductDto updateProductDto)
    {
        _logger.LogInformation("Updating product with id: {ProductId} with {@UpdatedProduct}", id, updateProductDto);
        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Product with id: {id} couldn't be found.");

        if (updateProductDto.UserId.HasValue) product.UserId = updateProductDto.UserId.Value;
        if (!string.IsNullOrEmpty(updateProductDto.Name)) product.Name = updateProductDto.Name;
        if (!string.IsNullOrEmpty(updateProductDto.Description)) product.Description = updateProductDto.Description;

        await _productRepository.SaveChanges();
    }

    public async Task DeleteProduct(int id)
    {
        _logger.LogInformation("deleting product with id: {ProductId}", id);

        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Product with id: {id} couldn't be found.");

        await _productRepository.DeleteProduct(product);
    }
}
