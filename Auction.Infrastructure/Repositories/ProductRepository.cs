using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Repositories;

internal class ProductRepository(AuctionDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await context.Products.ToListAsync();
        return products;
    }
}
