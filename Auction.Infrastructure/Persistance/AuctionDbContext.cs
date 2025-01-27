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
    internal DbSet<Domain.Entities.Auction> Auctions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Domain.Entities.Auction>()
            .HasOne(a => a.Product)
            .WithMany()
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(builder);
    }
}
