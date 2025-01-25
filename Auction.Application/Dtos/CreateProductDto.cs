using Auction.Domain.Entities;

namespace Auction.Application.Dtos;
public class CreateProductDto
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public static Product? ToProduct(CreateProductDto createProductDto)
    {
        return new Product
        {
            UserId = createProductDto.UserId,
            Name = createProductDto.Name,
            Description = createProductDto.Description
        };
    }
}
