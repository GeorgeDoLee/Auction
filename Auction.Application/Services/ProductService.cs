using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class ProductService : IProductService
{
    public async Task<IEnumerable<Product>> GetAllProducts(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        logger.LogInformation("getting all the products.");
        var products = await productRepository.GetAllAsync();
        return products;
    }
}
