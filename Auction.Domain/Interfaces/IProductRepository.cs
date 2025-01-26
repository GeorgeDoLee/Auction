using Auction.Domain.Entities;

namespace Auction.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<int> CreateProduct(Product product);
    Task DeleteProduct(Product product);
    Task SaveChanges();
}
