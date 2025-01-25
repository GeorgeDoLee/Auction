using Auction.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}
