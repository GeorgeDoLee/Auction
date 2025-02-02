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

        // Cascade delete between Sport and League
        builder.Entity<League>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(l => l.SportId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between League and Team
        builder.Entity<Team>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(t => t.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Prevent cascade delete for Team -> Sport relationship
        builder.Entity<Team>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(t => t.SportId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Product and Team
        builder.Entity<Product>()
            .HasOne<Team>()
            .WithMany()
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Prevent cascade delete for Product -> Match relationship
        builder.Entity<Product>()
            .HasOne<Match>()
            .WithMany()
            .HasForeignKey(p => p.MatchId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Product and League
        builder.Entity<Product>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(p => p.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Product and Sport
        builder.Entity<Product>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(p => p.SportId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Auction and Product
        builder.Entity<Domain.Entities.Auction>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Auction and User (Seller)
        builder.Entity<Domain.Entities.Auction>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.SellerId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Bid and Auction
        builder.Entity<Bid>()
            .HasOne<Domain.Entities.Auction>()
            .WithMany()
            .HasForeignKey(b => b.AuctionId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Bid and User (User making the bid)
        builder.Entity<Bid>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Match and League
        builder.Entity<Match>()
            .HasOne<League>()
            .WithMany()
            .HasForeignKey(m => m.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here

        // Cascade delete between Match and Sport
        builder.Entity<Match>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(m => m.SportId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete here
    }
}