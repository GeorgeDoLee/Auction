using Auction.Domain.Entities;

namespace Auction.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}