using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Repositories;

internal class SportRepository : Repository<Sport>, ISportRepository
{
    public SportRepository(AuctionDbContext context) : base(context)
    {
    }
}
