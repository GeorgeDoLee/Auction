using Auction.Domain.Constants;
using Auction.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace Auction.Infrastructure.Seeders;

internal class RolesSeeder : ISeeder
{
    private readonly AuctionDbContext _context;
    public RolesSeeder(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        var roles = GetRoles();
        _context.Roles.AddRange(roles);
        await _context.SaveChangesAsync();
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new (UserRoles.User),
                new (UserRoles.Admin)
            ];

        return roles;
    }
}
