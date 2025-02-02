namespace Auction.Domain.Entities;

public class Sport
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string IconUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<League> Leagues { get; set; } = new();
    public List<Team> Teams { get; set; } = new();
    public List<Match> Matches { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}