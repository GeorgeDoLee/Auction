namespace Auction.Domain.Entities;

public class League
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string LogoUrl { get; set; } = string.Empty;
    public int SportId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Sport? Sport { get; set; }
    public List<Team> Teams { get; set; } = new();
    public List<Match> Matches { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}
