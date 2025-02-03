using Auction.Domain.Entities;
using Auction.Domain.Exceptions;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        _logger.LogInformation("getting all the products.");

        var products = await _unitOfWork.Products.GetAllAsync();
        
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        _logger.LogInformation("getting product by id: {ProductId}", id);

        var product = await _unitOfWork.Products.GetAsync(id) 
            ?? throw new NotFoundException(nameof(Product), id.ToString());

        return product;
    }

    public async Task DeleteProduct(int id)
    {
        _logger.LogInformation("deleting product with id: {ProductId}", id);

        var product = await _unitOfWork.Products.GetAsync(id)
            ?? throw new NotFoundException(nameof(Product), id.ToString());

        await _unitOfWork.Products.RemoveAsync(product);
    }
}
