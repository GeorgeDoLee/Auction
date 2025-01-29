using Auction.Domain.Constants;
using Auction.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace Auction.Infrastructure.Seeders;

internal class RoleSeeder : ISeeder
{
    private readonly AuctionDbContext _context;
    public RoleSeeder(AuctionDbContext context)
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
                new (UserRoles.User)
                {
                    NormalizedName = UserRoles.User.ToUpper()
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.Admin.ToUpper()
                }
            ];

        return roles;
    }
}
