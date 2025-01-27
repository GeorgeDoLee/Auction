namespace Auction.Domain.Entities;

public class Auction
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public required decimal StartingPrice { get; set; }
    public required decimal CurrentPrice { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }

    public Product? Product { get; set; }
    public User? User { get; set; }
}
