using Auction.Domain.Entities;
using Auction.Domain.Enums;
using Auction.Infrastructure.Persistance;

namespace Auction.Infrastructure.Seeders;

internal class UserSeeder(AuctionDbContext context) : IUserSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Users.Any())
            {
                var admin = GetAdmin();
                context.Users.Add(admin);
                await context.SaveChangesAsync();
            }
        }
    }

    private User GetAdmin()
    {
        User admin = new User
        {
            Username = "First Admin",
            UserRole = UserRole.Admin,
        };

        return admin;
    }
}
