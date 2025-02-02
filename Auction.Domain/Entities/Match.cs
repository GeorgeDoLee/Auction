namespace Auction.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    public required string HomeTeam { get; set; }
    public required string AwayTeam { get; set; }
    public int ScoreHome { get; set; }
    public int ScoreAway { get; set; }
    public DateTime MatchDate { get; set; }
    public int LeagueId { get; set; }
    public int SportId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public League? League { get; set; }
    public Sport? Sport { get; set; }
    public List<Product> Products { get; set; } = new();
}
