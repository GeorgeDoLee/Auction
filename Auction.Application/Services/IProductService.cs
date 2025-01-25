using Auction.Application.Dtos;

namespace Auction.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(int id);
        Task<int> CreateProduct(CreateProductDto createProductDto);
    }
}