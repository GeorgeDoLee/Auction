using Auction.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISportService, SportService>();

        services.AddValidatorsFromAssembly(appAssembly)
            .AddFluentValidationAutoValidation();
    }
}
