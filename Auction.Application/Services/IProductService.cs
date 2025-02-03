
using Auction.Domain.Entities;

namespace Auction.Application.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task DeleteProduct(int id);
}