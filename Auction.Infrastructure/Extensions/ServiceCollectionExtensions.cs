using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;
using Auction.Infrastructure.Repositories;
using Auction.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuctionDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISeeder, ProductSeeder>();
        services.AddScoped<ISeeder, UserSeeder>();
        services.AddScoped<DatabaseSeeder>();
    }
}
