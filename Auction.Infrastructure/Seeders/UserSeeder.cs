using Auction.Domain.Entities;
using Auction.Domain.Enums;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Seeders;

internal class UserSeeder : ISeeder
{
    private readonly AuctionDbContext _context;

    public UserSeeder(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        var user = GetUser();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    private User GetUser()
    {
        var user = new User
        {
            Username = "John Doe",
            UserRole = UserRole.Admin,
        };

        return user;
    }
}
