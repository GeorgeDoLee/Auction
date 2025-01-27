using Auction.Domain.Entities;

namespace Auction.Application.Dtos;

public class UpdateProductDto
{
    public int? UserId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
