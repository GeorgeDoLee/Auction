namespace Auction.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public User? User { get; set; }
}
