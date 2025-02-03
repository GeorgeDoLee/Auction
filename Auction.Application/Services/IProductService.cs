using Auction.Domain.Entities;

namespace Auction.Application.Services;

public interface IProductService
{
    Task DeleteProduct(int id);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
}