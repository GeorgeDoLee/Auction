using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services
{
    internal interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(IProductRepository productRepository, ILogger<ProductService> logger);
    }
}