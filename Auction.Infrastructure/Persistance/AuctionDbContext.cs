using Auction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistance;

internal class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

    internal DbSet<Sport> Sports { get; set; }
    internal DbSet<League> Leagues { get; set; }
    internal DbSet<Team> Teams { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Domain.Entities.Auction> Auctions { get; set; }
    internal DbSet<Bid> Bids { get; set; }
    internal DbSet<Match> Matches { get; set; }
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<League>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(l => l.SportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Team>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(t => t.LeagueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne<Team>()
            .WithMany()
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne<Match>()
            .WithMany()
            .HasForeignKey(p => p.MatchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(p => p.LeagueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(p => p.SportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Domain.Entities.Auction>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Domain.Entities.Auction>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.SellerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Bid>()
            .HasOne<Domain.Entities.Auction>()
            .WithMany()
            .HasForeignKey(b => b.AuctionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Bid>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Match>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(m => m.LeagueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Match>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(m => m.SportId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}