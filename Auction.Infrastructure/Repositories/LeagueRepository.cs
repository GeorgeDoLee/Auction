using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Repositories;

internal class LeagueRepository : Repository<League>, ILeagueRepository
{
    public LeagueRepository(AuctionDbContext context) : base(context)
    {
    }
}
