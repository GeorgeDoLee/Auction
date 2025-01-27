using Auction.Domain.Entities;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Seeders;

internal class ProductSeeder : ISeeder
{
    private readonly AuctionDbContext _context;

    public ProductSeeder(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        var product = GetProduct();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    private Product GetProduct()
    {
        var product = new Product
        {
            Name = "Test Product",
            Description = "Test Products Description"
        };

        return product;
    }
}
