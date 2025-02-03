using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Repositories;

internal class ProductRepository : Repository<Product>, IProductRepository
{

    public ProductRepository(AuctionDbContext context) : base(context)
    {
    }
}