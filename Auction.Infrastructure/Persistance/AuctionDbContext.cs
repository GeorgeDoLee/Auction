using Auction.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistance;

internal class AuctionDbContext : IdentityDbContext<User>
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    internal DbSet<Product> Products { get; set; }
}
