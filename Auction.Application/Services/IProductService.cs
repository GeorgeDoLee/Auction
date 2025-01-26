using Auction.Application.Dtos;

namespace Auction.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(int id);
        Task<int> CreateProduct(CreateProductDto createProductDto);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, UpdateProductDto updateProductDto);
    }
}