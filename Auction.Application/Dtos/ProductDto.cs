using Auction.Domain.Entities;

namespace Auction.Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public static ProductDto? FromEntity(Product? product)
    {
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
        };
    }
}
