namespace Auction.Infrastructure.Seeders;

public class DatabaseSeeder
{
    private readonly IEnumerable<ISeeder> _seeders;

    public DatabaseSeeder(IEnumerable<ISeeder> seeders)
    {
        _seeders = seeders;
    }

    public async Task SeedAsync()
    {
        foreach (var seeder in _seeders)
        {
            await seeder.Seed();
        }
    }
}
