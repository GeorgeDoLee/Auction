namespace Auction.Domain.Entities;

public class Auction
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SellerId { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public required string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Product? Product { get; set; }
    public User? Seller { get; set; }
    public List<Bid> Bids { get; set; } = new();
}
