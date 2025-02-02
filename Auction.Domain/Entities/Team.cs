namespace Auction.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string LogoUrl { get; set; } = string.Empty;
    public int LeagueId { get; set; }
    public int SportId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public League? League { get; set; }
    public Sport? Sport { get; set; }
    public List<Product> Products { get; set; } = new();
}
