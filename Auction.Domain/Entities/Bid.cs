namespace Auction.Domain.Entities;

public class Bid
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AuctionId { get; set; }
    public decimal BidAmount { get; set; }
    public DateTime BidTime { get; set; }
    public bool IsWinner { get; set; } = false;
    public User? User { get; set; }
    public Auction? Auction { get; set; }
}
